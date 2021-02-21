using System;
using AutoMapper;
using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infraestrutura.API.ViewModel;

namespace DBCorp.Infraestrutura.API.AutoMapper.DomainToViewModel
{
	public class PessoaJuridicaMappingProfile : Profile
	{
		public PessoaJuridicaMappingProfile()
		{
			CreateMap<PessoaJuridica, PessoaJuridicaViewModel>()
			.ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id))
			.ForMember(vm => vm.NomeFantasia, map => map.MapFrom(m => m.NomeFantasia))
			.ForMember(vm => vm.Cnpj, map => map.MapFrom(m => m.Cnpj))
			.ForMember(vm => vm.RazaoSocial, map => map.MapFrom(m => m.RazaoSocial))
			.ForMember(vm => vm.DtFundacao, map => map.MapFrom(m => m.DtFundacao.HasValue ? m.DtFundacao.Value.ToShortDateString() : DateTime.MinValue.Date.ToShortDateString()));
		}
	}
}
