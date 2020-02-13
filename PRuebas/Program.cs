using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PRuebas
{
    class Program
    {
        static void Main(string[] args)
        {
            string palabra = "@HOLA CoMÓ Estás";

            Console.WriteLine(palabra);
            Console.WriteLine(normalizar(palabra));
            Console.ReadLine();
        }
        private static string normalizar(string texto)
        {
            return Regex.Replace(SinTildes(texto), @"[^a-zA-z0-9 ]+", "").ToLower();
        }
        private static string SinTildes(string texto) {
            texto = new String(
                texto.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray()
            )
            .Normalize(NormalizationForm.FormC);
            return texto;
        }
    }
}
