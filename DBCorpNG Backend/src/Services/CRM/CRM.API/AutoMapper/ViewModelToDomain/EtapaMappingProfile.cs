using AutoMapper;
using DBCorp.CRM.Domain.Models.FunilAggregation;

namespace DBCorp.CRM.API.AutoMapper.ViewModelToDomain
{
    public class EtapaMappingProfile : Profile
    {


        public EtapaMappingProfile()
        {
            CreateMap<ViewModel.EtapaViewModel, FunilEtapa>()

                .ForMember(dm => dm.Ativo, map => map.MapFrom(vm => true));
        }
    }
}
