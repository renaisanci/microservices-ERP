using AutoMapper;
using DBCorp.CRM.API.ViewModel;
using DBCorp.CRM.Domain.Models.FunilAggregation;
using System.Linq;
 

namespace DBCorp.CRM.API.AutoMapper.DomainToViewModel
{
    public class FunilMappingProfile : Profile
    {




        public FunilMappingProfile()
        {
            CreateMap<Funil, FunilViewModel>()
                .ForMember(vm => vm.TotalEtapas, map => map.MapFrom(vm => System.DateTime.Now.Second))
                .ForMember(vm => vm.Etapas, map => map.MapFrom(vm => vm.Etapas))
                .ForMember(vm => vm.EtapasLink, map => map.MapFrom(vm => string.Join(" > ", vm.Etapas.OrderBy(x => x.Ordem).Select(x => x.Nome))));
            //  .ForMember(vm => vm.Etapas, map => map.MapFrom(m => (Mapper.Map<IEnumerable<FunilEtapa>, IEnumerable<EtapaViewModel>>(m.Etapas))));
        }

    }

       
}
