using AutoMapper;
using DBCorp.ControleAcesso.API.ViewModel;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.API.AutoMapper.ViewModelToDomain
{
	public class UsuarioMappingProfile : Profile
	{
		public UsuarioMappingProfile()
		{
			CreateMap<UsuarioViewModel, Usuario>();
		}
	}
}
