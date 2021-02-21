using AutoMapper;
using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infraestrutura.API.ViewModel;

namespace DBCorp.Infraestrutura.API.AutoMapper.ViewModelToDomain
{
	public class PessoaFisicaMappingProfile : Profile
	{
		public PessoaFisicaMappingProfile()
		{
			CreateMap<PessoaFisicaViewModel, PessoaFisica>();
		}
	}
}
