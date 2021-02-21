using AutoMapper;
using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infraestrutura.API.ViewModel;

namespace DBCorp.Infraestrutura.API.AutoMapper.ViewModelToDomain
{
	public class PessoaJuridicaMappingProfile : Profile
	{
		public PessoaJuridicaMappingProfile()
		{
			CreateMap<PessoaJuridicaViewModel, PessoaJuridica>();
		}
	}
}
