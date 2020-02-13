using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.App_Start.Extenciones
{
    public static class Listas
    {
        public static IEnumerable<SelectListItem> GenerarLista<T>(this IEnumerable<T> lista, bool todos = false)
        {
            var listaTmp = new List<SelectListItem>();

            if (todos)
                listaTmp.Add(new SelectListItem { Text = "TODOS", Value = string.Empty });

            listaTmp.AddRange(Mapper.Map<IEnumerable<SelectListItem>>(lista));
            return listaTmp;
        }
    }
}