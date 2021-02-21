using AutoMapper;
using DBCorp.CRM.Domain.Models.NegocioAggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCorp.CRM.API.AutoMapper.ViewModelToDomain
{
    public class NegocioMappingProfile : Profile
    {



        public NegocioMappingProfile()
        {
            CreateMap<ViewModel.NegocioViewModel, Negocio>()
           .ForMember(dm => dm.Ativo, map => map.MapFrom(vm => true))
           .ForMember(dm => dm.DataFechamentoEsperada, map => map.MapFrom(vm => DateTime.Parse(vm.DataFechamento)))
           .ForMember(dm => dm.DataHoraCriacao, map => map.MapFrom(vm => DateTime.Now))
           .ForMember(dm => dm.ValorPrevisto, map => map.MapFrom(vm => vm.ValorNegocio))

            ;
 
        }
    }
}
