using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TareaProcesamiento
{
    public class UTIL_FUNCIONES
    {
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0);// + strStart.Length;
                End = strSource.IndexOf(strEnd, Start) + strEnd.Length;
                //return strSource.Substring(Start, End - Start);
                return strSource.Substring(Start, End);
            }
            else
            {
                return "";
            }
        }

        public static void getBetweenArray(List<BE_PALABRA> lstPalabrasBE,
            string strStart, string strEnd, int nivel,
            out string strTextoOut, out List<BE_PALABRA> lstPalabraOut) {
            int estado = 0;
            string textoSalida = "";
            List<BE_PALABRA> palabrasSalida = new List<BE_PALABRA>();
            try
            {
                for (int x = nivel; x < lstPalabrasBE.Count; x++)
                {
                    if (normalizar(lstPalabrasBE[x].Texto) == normalizar(strStart))
                    {
                        estado = 1;
                    }
                    else if (estado == 1 && normalizar(lstPalabrasBE[x].Texto) == normalizar(strEnd))
                    {
                        estado = 2;
                    }

                    if (estado != 0)
                    {
                        textoSalida += lstPalabrasBE[x].Texto + " ";
                        palabrasSalida.Add(lstPalabrasBE[x]);
                    }

                    if (estado == 2)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex) {
                throw ex;
            }

            //foreach (BE_PALABRA objPalabraBE in lstPalabrasBE) {
            //    if (normalizar(objPalabraBE.Texto) == normalizar(strStart)) {
            //        estado = 1;
            //    } else if (estado == 1 && normalizar(objPalabraBE.Texto) == normalizar(strEnd)) {
            //        estado = 2;
            //    }

            //    if (estado != 0) {
            //        textoSalida += objPalabraBE.Texto + " ";
            //        palabrasSalida.Add(objPalabraBE);
            //    }

            //    if (estado == 2) {
            //        break;
            //    }
            //}

            strTextoOut = textoSalida.Trim();
            lstPalabraOut = palabrasSalida;
        }

        public static string normalizar(string texto)
        {
            return Regex.Replace(SinTildes(texto), @"[^a-zA-z0-9 ]+", "").ToLower();
        }

        private static string SinTildes(string texto)
        {
            texto = new String(
                texto.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray()
            )
            .Normalize(NormalizationForm.FormC);
            return texto;
        }

        public static int LevenshteinDistance(string s, string t, out double porcentaje)
        {
            porcentaje = 0;

            // d es una tabla con m+1 renglones y n+1 columnas
            int costo = 0;
            int m = s.Length;
            int n = t.Length;
            int[,] d = new int[m + 1, n + 1];

            // Verifica que exista algo que comparar
            if (n == 0) return m;
            if (m == 0) return n;

            // Llena la primera columna y la primera fila.
            for (int i = 0; i <= m; d[i, 0] = i++) ;
            for (int j = 0; j <= n; d[0, j] = j++) ;


            /// recorre la matriz llenando cada unos de los pesos.
            /// i columnas, j renglones
            for (int i = 1; i <= m; i++)
            {
                // recorre para j
                for (int j = 1; j <= n; j++)
                {
                    /// si son iguales en posiciones equidistantes el peso es 0
                    /// de lo contrario el peso suma a uno.
                    costo = (s[i - 1] == t[j - 1]) ? 0 : 1;
                    d[i, j] = System.Math.Min(System.Math.Min(d[i - 1, j] + 1,  //Eliminacion
                                  d[i, j - 1] + 1),                             //Insercion 
                                  d[i - 1, j - 1] + costo);                     //Sustitucion
                }
            }

            /// Calculamos el porcentaje de cambios en la palabra.
            if (s.Length > t.Length)
                porcentaje = ((double)d[m, n] / (double)s.Length);
            else
                porcentaje = ((double)d[m, n] / (double)t.Length);
            return d[m, n];
        }

        internal static List<int> obtenerPosicionesTexto(
            List<BE_PALABRA> lstPalabraBE, string texto)
        {
            List<int> lstPosicionBE = new List<int>();
            for (int x = 0; x < lstPalabraBE.Count; x++) {
                if (normalizar(lstPalabraBE[x].Texto) == normalizar(texto)) {
                    lstPosicionBE.Add(x);
                }
            }
            return lstPosicionBE;
        }
    }
}
