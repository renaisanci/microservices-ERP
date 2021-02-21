using AutoMapper;
using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.ControleAcesso.API.ViewModel;

namespace DBCorp.ControleAcesso.API.AutoMapper.ViewModelToDomain
{
	public class PerfilUsuarioMappingProfile : Profile
	{
		public PerfilUsuarioMappingProfile()
		{
			CreateMap<PerfilUsuarioViewModel, PerfilUsuario>();
		}
	}
}
