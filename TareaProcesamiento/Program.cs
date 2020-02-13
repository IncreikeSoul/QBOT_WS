using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TareaProcesamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            //Procesamiento objProcesamiento = new Procesamiento();

            //objProcesamiento.AddWords();
            //objProcesamiento.ListWords();

            //objProcesamiento.addCorpus();
            //objProcesamiento.listCorpus();

            //objProcesamiento.TrainLanguageModel();

            //string resultado = objProcesamiento.Recognize(@"data/audioPrueba.wav");
            //Console.WriteLine(resultado);

            //System.Console.Read();

            string url = "http://localhost:8077";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }

            System.Console.Read();
        }
    }

    class Startup {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }

    public class SincronizarHub : Hub {
        public void listarArchivosFTP(string codigo) {
            try
            {
                Console.WriteLine("Codigo: " + codigo);
                BE_FTP objFtpBE = new BE_FTP();

                BL_AUDIO objAudioBL = new BL_AUDIO();
                objFtpBE = objAudioBL.obtenerDatosFtp(codigo);

                var ftp = new FtpHelper(
                    new FtpSettings
                    {
                        Server = objFtpBE.Server,
                        Port = objFtpBE.Port,
                        RemoteFolderPath = objFtpBE.Folder,//"/Folder",
                        User = objFtpBE.Username,
                        Password = objFtpBE.Password
                    }
                );

                List<FtpFile> lstFtpFile = ftp.GetRemoteFiles();
                foreach (FtpFile objFileBE in lstFtpFile) {
                    Clients.All.listarProcesamientoFtp(objFileBE.FileName, objFileBE.TimeStamp);
                }
            }
            catch (Exception ex) {
                Clients.All.mensajeError(ex.Message);
            }
        }

        public void sincronizarFTP(string codigoFTP, string codigoNegocio, string codigoSpeech, string codigoAgente) {
            Procesamiento objProcesamientoBL = null;
            List<BE_PALABRA> lstTextoBE = new List<BE_PALABRA>();
            BE_FTP objFtpBE = new BE_FTP();

            BL_AUDIO objAudioBL = new BL_AUDIO();
            objFtpBE = objAudioBL.obtenerDatosFtp(codigoFTP);
            lstTextoBE = objAudioBL.obtenerPalabrasSpeech(codigoSpeech);

            var ftp = new FtpHelper(
                new FtpSettings
                {
                    Server = objFtpBE.Server,
                    Port = objFtpBE.Port,
                    RemoteFolderPath = objFtpBE.Folder,//"/Folder",
                    User = objFtpBE.Username,
                    Password = objFtpBE.Password
                }
            );

            List<FtpFile> lstFileBE = ftp.GetRemoteFiles();

            FtpWebRequest request = null;
            FtpWebResponse response = null;
            Stream responseStream = null;
            byte[] audio = null;

            foreach (FtpFile objFileBE in lstFileBE)
            {
                BE_TRANSCRIPCION objTranscripcionBE = new BE_TRANSCRIPCION();
                objTranscripcionBE.Texto = "";
                objTranscripcionBE.lstPalabraBE = new List<BE_PALABRA>();

                objTranscripcionBE.IdNegocio = Convert.ToInt32(codigoNegocio);
                objTranscripcionBE.IdSpeech = Convert.ToInt32(codigoSpeech);
                objTranscripcionBE.IdAgente = Convert.ToInt32(codigoAgente);
                objTranscripcionBE.NumeroEntrada = "987654321";

                objProcesamientoBL = new Procesamiento();
                request = (FtpWebRequest)WebRequest.Create("ftp://" + objFtpBE.Server + "/" + objFileBE.FileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(objFtpBE.Username, objFtpBE.Password);
                request.UsePassive = false;

                response = (FtpWebResponse) request.GetResponse();

                responseStream = response.GetResponseStream();

                audio = objProcesamientoBL.ReadFully(responseStream);

                //DESCARGANDO EL AUDIO
                string rutaRegistrarAudio = @"C:\Proyectos\Repositorio\Aplicativos\ListenToMeInterseguros\Q-Bot\Call.Cloud.Mvc\Content\audios\" + objFileBE.FileName;
                //string rutaRegistrarAudio = @"C:\Pase_produccion\csacsa.wav";
                File.WriteAllBytes(rutaRegistrarAudio, audio);

                //RECONOCIENDO EL AUDIO
                string resultado = objProcesamientoBL.LeerAudio(audio);

                objTranscripcionBE.RutaCompleta = @"\Content\audios\" + objFileBE.FileName; // "ftp://" + objFtpBE.Server + "/" + objFileBE.FileName;
                objTranscripcionBE.NombreArchivo = objFileBE.FileName;
                objTranscripcionBE.FechaCreacion = DateTime.Now;
                objTranscripcionBE.TamanoAudio = Convert.ToString(audio.Length);

                BE_PALABRA objPalabraBE = null;
                Dictionary<string, Object> json_data = (Dictionary<string, Object>)
                                new JavaScriptSerializer().DeserializeObject(resultado);

                foreach (KeyValuePair<string, Object> data in json_data)
                {
                    if (data.Key == "results")
                    {
                        foreach (Object result in (Object[])data.Value)
                        {
                            foreach (KeyValuePair<string, Object> dataResult in (Dictionary<string, Object>)result)
                            {
                                if (dataResult.Key == "alternatives")
                                {
                                    foreach (Object alternatives in (Object[])dataResult.Value)
                                    {
                                        foreach (KeyValuePair<string, Object> alternative in (Dictionary<string, Object>)alternatives)
                                        {
                                            if (alternative.Key == "timestamps")
                                            {
                                                foreach (Object palabras in (Object[])alternative.Value)
                                                {
                                                    Object[] palabra = (Object[])palabras;
                                                    string strPalabra = (String)palabra[0];
                                                    float floatInicio = float.Parse(palabra[1].ToString());
                                                    float floatFin = float.Parse(palabra[2].ToString());
                                                    objPalabraBE = new BE_PALABRA();
                                                    objPalabraBE.Texto = strPalabra;
                                                    objPalabraBE.Inicio = floatInicio;
                                                    objPalabraBE.Fin = floatFin;
                                                    objTranscripcionBE.lstPalabraBE.Add(objPalabraBE);
                                                }
                                            }
                                            else if (alternative.Key == "confidence")
                                            {
                                                decimal decCoincidencia = (Decimal)alternative.Value;
                                            }
                                            else if (alternative.Key == "transcript")
                                            {
                                                string strTexto = (string)alternative.Value;
                                                objTranscripcionBE.Texto += strTexto.Trim() + " ";
                                            }
                                        }
                                    }
                                }
                                else if (dataResult.Key == "final")
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                /*REGISTRANDO EL AUDIO*/
                bool registroAudio = objAudioBL.registrarAudio(objTranscripcionBE);

                if (registroAudio)
                {
                    Console.WriteLine("Registro de audio realizado correctamente.");
                    Clients.All.listarDatosProcesamientoFtp(
                        objTranscripcionBE.NombreArchivo, 
                        objTranscripcionBE.FechaCreacion,
                        objTranscripcionBE.TamanoAudio,
                        objTranscripcionBE.Texto,
                        "Registrado"
                        );

                    //REGISTRANDO LA TRANSCRIPCION Y DESGLOZANDO EL TEXTO
                    if (objTranscripcionBE.lstPalabraBE.Count > 0)
                    {
                        foreach (BE_PALABRA speech in lstTextoBE) {
                            string[] arrSpeech = speech.word.Split(' ');
                            List<int> posicionTexto = new List<int>();
                            posicionTexto = UTIL_FUNCIONES.
                                obtenerPosicionesTexto(objTranscripcionBE.lstPalabraBE,
                                arrSpeech.First());

                            for (int x = 0; x < posicionTexto.Count; x++) {
                                if (arrSpeech.Length > 1)
                                {
                                    string textoEntrePalabras = "";
                                    List<BE_PALABRA> listaPalabras = null;

                                    UTIL_FUNCIONES.getBetweenArray(objTranscripcionBE.lstPalabraBE,
                                        arrSpeech.First(), arrSpeech.Last(), posicionTexto[x],
                                        out textoEntrePalabras, out listaPalabras);

                                    double porcentajeCoincidencia = 0;

                                    int resultadoCoincidencia = UTIL_FUNCIONES.LevenshteinDistance(
                                        speech.word,
                                        textoEntrePalabras,
                                        out porcentajeCoincidencia);

                                    if (resultadoCoincidencia < 3)
                                    {
                                        //INSERTAR LAS PALABRAS CORRECTAS
                                        speech.PK_audio = objTranscripcionBE.IdAudio;
                                        objAudioBL.registrarPalabraDetalle(speech);
                                    }
                                }
                                else
                                {
                                    foreach (BE_PALABRA palabra in objTranscripcionBE.lstPalabraBE)
                                    {
                                        if (UTIL_FUNCIONES.normalizar(palabra.Texto) == 
                                            UTIL_FUNCIONES.normalizar(speech.word))
                                        {
                                            //objAudioBL.registrarPalabraDetalle(palabra);
                                            speech.PK_audio = objTranscripcionBE.IdAudio;
                                            objAudioBL.registrarPalabraDetalle(speech);
                                        }
                                    }
                                }
                            }
                            


                            //foreach (BE_PALABRA palabra in objTranscripcionBE.lstPalabraBE)
                            //{
                            //    validarPalabra(palabra, speech);
                            //}
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Ocurrio un error en el registro del audio.");
                    Clients.All.listarDatosProcesamientoFtp(
                        objTranscripcionBE.NombreArchivo,
                        objTranscripcionBE.FechaCreacion,
                        objTranscripcionBE.TamanoAudio,
                        objTranscripcionBE.Texto,
                        "Error"
                        );
                }

                //StreamReader reader = new StreamReader(responseStream);
                //Console.WriteLine(resultado);
                Console.WriteLine($"Download Complete, status {response.StatusDescription}");

                //reader.Close();
                response.Close();
            }
        }
    }
}
