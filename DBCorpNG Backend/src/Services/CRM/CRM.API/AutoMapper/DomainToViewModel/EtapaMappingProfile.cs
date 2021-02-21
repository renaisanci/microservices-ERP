using AutoMapper;
using DBCorp.CRM.API.ViewModel;
using DBCorp.CRM.Domain.Models.FunilAggregation;

namespace DBCorp.CRM.API.AutoMapper.DomainToViewModel
{
    public class EtapaMappingProfile : Profile
    {



        public EtapaMappingProfile()
        {
            CreateMap<FunilEtapa, EtapaViewModel>()
            .ForMember(vm => vm.Negocios, map => map.MapFrom(vm => vm.Negocios));



        }

    }
}
