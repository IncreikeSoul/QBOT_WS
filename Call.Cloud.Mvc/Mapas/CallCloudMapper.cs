using AutoMapper;
using Call.Cloud.Modelo;
using Call.Cloud.Mvc.Models.AgentVM;
using Call.Cloud.Mvc.Models.ReportsVM;
using Call.Cloud.Mvc.Models.SectionVM;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Call.Cloud.Mvc.Mapas
{
    public class CallCloudMapper:Profile    
    {
        protected override void Configure()
        {
            #region Agent
            Mapper.CreateMap<Agent, AgentVm>();
            Mapper.CreateMap<AgentVm, Agent>();      
            #endregion

            #region Business
            Mapper.CreateMap<Business, SelectListItem>()
                .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.nameBusiness))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.PK_Business));
            Mapper.CreateMap<IEnumerable<Business>, IList<SelectListItem>>();
            #endregion

            //#region Office
            //Mapper.CreateMap<Office, SelectListItem>()
            //    .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.nameOffice))
            //    .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.PkOffice));
            //Mapper.CreateMap<IEnumerable<Office>, IList<SelectListItem>>();
            //#endregion

            #region SubOffice
            //Mapper.CreateMap<SubOffice, SelectListItem>()
            //    .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.nameSubOffice))
            //    .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.PkSubOffice));
            //Mapper.CreateMap<IEnumerable<SubOffice>, IList<SelectListItem>>();
            #endregion

            #region Agente1
            Mapper.CreateMap<Agent, SelectListItem>()
               .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.FirstName))
               .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.PkAgent));
            Mapper.CreateMap<IEnumerable<Agent>, IList<SelectListItem>>();
            #endregion

            #region Enterprise
            //Mapper.CreateMap<Enterprise, SelectListItem>()
            //    .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.enterPrise))
            //    .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.PkenterPrise));
            //Mapper.CreateMap<IEnumerable<Enterprise>, IList<SelectListItem>>();
            #endregion

            #region Category
            Mapper.CreateMap<Category, SelectListItem>()
               .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.Name))
               .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.PkCat));
            Mapper.CreateMap<IEnumerable<Category>, IList<SelectListItem>>();
            #endregion

            #region Section
            //Mapper.CreateMap<Section, SelectListItem>()
            //   .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.SectionName))
            //   .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.PkSection));
            //Mapper.CreateMap<IEnumerable<Section>, IList<SelectListItem>>();

            //Mapper.CreateMap<WordRuleSectionVm, Section>();
            //Mapper.CreateMap<Section, WordRuleSectionVm>();     

            #endregion

            #region Speech
            //Mapper.CreateMap<Speech, SelectListItem>()
            //   .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.SpeechName))
            //   .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.PkSpeech));
            //Mapper.CreateMap<IEnumerable<Speech>, IList<SelectListItem>>();
            #endregion

            #region Reglas
            Mapper.CreateMap<Rule, SelectListItem>()
                .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.NameRule))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.PkRule));
            Mapper.CreateMap<IEnumerable<Rule>, IList<SelectListItem>>();
            #endregion

            #region WordRule
            Mapper.CreateMap<WordRule, SelectListItem>()
                .ForMember(vm => vm.Text, opt => opt.MapFrom(l => l.name))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(l => l.PkWorldRule));
            Mapper.CreateMap<IEnumerable<WordRule>, IList<SelectListItem>>();
            #endregion

            #region 
            Mapper.CreateMap<ReportVmOffice, ReportVmOffice>();
            Mapper.CreateMap<ReportVmOffice, ReportVmOffice>();
            #endregion

        }
    }
}