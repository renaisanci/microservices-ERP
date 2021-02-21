using AutoMapper;
using DBCorp.CRM.Domain.Models.FunilAggregation;

namespace DBCorp.CRM.API.AutoMapper.ViewModelToDomain
{
    public class FunilMappingProfile : Profile
    {


        public FunilMappingProfile()
        {
            CreateMap<ViewModel.FunilViewModel, Funil>()


                .ForMember(dm => dm.Ativo, map => map.MapFrom(vm => true))
                .ForMember(vm => vm.Etapas, map => map.MapFrom(vm => vm.Etapas));
        }

    }
}
