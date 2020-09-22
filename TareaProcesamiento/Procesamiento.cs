using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http;
using IBM.Cloud.SDK.Core.Http.Exceptions;
using IBM.Watson.SpeechToText.v1;
using IBM.Watson.SpeechToText.v1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TareaProcesamiento
{
    public class Procesamiento
    {
        private string apikey = "qTGvie2sZqAU4XmWpXeOq4-hKDXVjm9L8aM_j4892D7h";
        private string url = "https://gateway-wdc.watsonplatform.net/speech-to-text/api";
        /*private string apikey = "qhDLuH-BBe38XdKpRql4jNeRCJvPDKyv5Qmv8TxhVf28";
        private string url = "https://gateway-lon.watsonplatform.net/speech-to-text/api";*/
        //string url = "https://stream.watsonplatform.net/speech-to-text/api";
        private string corpusPath = @"data/palabras.txt";

        private string corpusName ="Prueba";
        private string customizationId = "4f340cd9-5afc-4648-8b93-a3ce71afca4f";

        //public Procesamiento()
        //{
        //    IamConfig config = new IamConfig(
        //        apikey: apikey
        //        );

        //    SpeechToTextService service = new SpeechToTextService(config);
        //    service.SetEndpoint(url);
        //    service.DisableSslVerification(true);

        //    var result = service.CreateLanguageModel(
        //        name: "modeloPrueba",
        //        baseModelName: "es-PE_NarrowbandModel",// "es-PE_NarrowbandModel" //"es-PE_BroadbandModel"
        //        dialect: "es-PE"
        //        );

        //    customizationId = result.Result.CustomizationId;

        //    Console.WriteLine(result.Response);
        //}

        public string Recognize(string audioPath)
        {
            try
            {
                IamConfig config = new IamConfig(
                    apikey: apikey
                    );

                SpeechToTextService service = new SpeechToTextService(config);
                service.SetEndpoint(url);


                var audio = File.ReadAllBytes(audioPath);
                var result = service.Recognize(
                    audio: audio,
                    contentType: "audio/wav",
                    model: "es-PE_NarrowbandModel",
                    timestamps: true//,
                    //customizationId: customizationId//,
                    //keywords: new List<string>() { "jahir", "sobrino" }
                    );

                return result.Response;
            }
            catch (ServiceResponseException sex) {
                return sex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal string LeerAudio(byte[] audio)
        {
            try
            {
                IamConfig config = new IamConfig(
                    apikey: apikey
                    );

                SpeechToTextService service = new SpeechToTextService(config);
                service.SetEndpoint(url);

                var result = service.Recognize(
                    audio: audio,
                    contentType: "audio/wav",
                    model: "es-PE_NarrowbandModel",
                    timestamps: true,
                    inactivityTimeout: 60000
                    );

                return result.Response;
            }
            catch (ServiceResponseException sex)
            {
                Console.WriteLine(sex);
                return sex.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ex.Message;
            }
        }

        public void addCorpus() {
            IamConfig config = new IamConfig(
                apikey: apikey
                );

            SpeechToTextService service = new SpeechToTextService(config);
            service.SetEndpoint(url);

            DetailedResponse<object> resultCorpus = null;
            using (FileStream fs = File.OpenRead(corpusPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    resultCorpus = service.AddCorpus(
                        customizationId: customizationId,
                        corpusName: corpusName,
                        corpusFile: ms
                        );
                }
            }

            Console.WriteLine(resultCorpus.Response);
        }

        public void listCorpus()
        {
            IamConfig config = new IamConfig(
                apikey: apikey
                );

            SpeechToTextService service = new SpeechToTextService(config);
            service.SetEndpoint(url);

            var resultListCorpus = service.GetCorpus(
                customizationId: customizationId,
                corpusName: corpusName
                );

            Console.WriteLine(resultListCorpus.Response);
        }

        public void AddWords()
        {
            IamConfig config = new IamConfig(
                apikey: apikey
                );

            SpeechToTextService service = new SpeechToTextService(config);
            service.SetEndpoint(url);

            var words = new List<CustomWord>()
            {
                new CustomWord()
                {
                    DisplayAs = "Jair",
                    SoundsLike = new List<string>()
                    {
                        "yahir", "jahir", "jair", "yair"
                    },
                    Word = "yahir"
                }
            };

            var resultWord = service.AddWords(
                customizationId: customizationId,
                words: words
                );

            Console.WriteLine(resultWord.Response);
        }

        public void ListWords()
        {
            IamConfig config = new IamConfig(
                apikey: apikey
                );

            SpeechToTextService service = new SpeechToTextService(config);
            service.SetEndpoint(url);

            var result = service.ListWords(
                customizationId: customizationId
                );

            Console.WriteLine(result.Response);
        }

        public void TrainLanguageModel()
        {
            IamConfig config = new IamConfig(
                apikey: apikey
                );

            SpeechToTextService service = new SpeechToTextService(config);
            service.SetEndpoint(url);

            var result = service.TrainLanguageModel(
                customizationId: customizationId
                );

            Console.WriteLine(result.Response);
        }

        public byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
