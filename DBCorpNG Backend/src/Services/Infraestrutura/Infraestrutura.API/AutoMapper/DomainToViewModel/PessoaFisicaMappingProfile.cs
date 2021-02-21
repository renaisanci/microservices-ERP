using System;
using AutoMapper;
using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infraestrutura.API.ViewModel;

namespace DBCorp.Infraestrutura.API.AutoMapper.DomainToViewModel
{
	public class PessoaFisicaMappingProfile : Profile
	{
		public PessoaFisicaMappingProfile()
		{
			CreateMap<PessoaFisica, PessoaFisicaViewModel>()
			.ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id))
			.ForMember(vm => vm.Nome, map => map.MapFrom(m => m.Nome))
			.ForMember(vm => vm.Sobrenome, map => map.MapFrom(m => m.Sobrenome))
			.ForMember(vm => vm.Cpf, map => map.MapFrom(m => m.Cpf))
			.ForMember(vm => vm.DtNascimento, map => map.MapFrom(m => m.DataNascimento.HasValue ? m.DataNascimento.Value.ToShortDateString() : DateTime.MinValue.Date.ToShortDateString()));
		}
	}
}
