using AutoMapper;
using DBCorp.CRM.Domain.Models.NegocioAggregation;
 

namespace DBCorp.CRM.API.AutoMapper.DomainToViewModel
{
    public class NegocioMappingProfile : Profile
    {
        public NegocioMappingProfile()
        {
            CreateMap<Negocio, ViewModel.NegocioViewModel>()
           .ForMember(dm => dm.ValorNegocio, map => map.MapFrom(vm => vm.ValorPrevisto))
                ;

   
        }

    }
}
