using AutoMapper;
using Call.Cloud.Mvc.Mapas;

namespace Call.Cloud.Mvc.Mapas
{
    public class MapperInitial
    {
        public static void Init()
        {
            Mapper.Initialize(x=>x.AddProfile(new CallCloudMapper()));
        }
    }
}