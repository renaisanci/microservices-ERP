using AutoMapper;
using DBCorp.ControleAcesso.API.ViewModel;
using DBCorp.ControleAcesso.Domain.Model;

namespace DBCorp.ControleAcesso.API.AutoMapper.DomainToViewModel
{
	public class PerfilUsuarioMappingProfile : Profile
	{
		public PerfilUsuarioMappingProfile()
		{
			CreateMap<PerfilUsuario, PerfilUsuarioViewModel>()
			.ForMember(vm => vm.PerfilId, map => map.MapFrom(m => m.Perfil.Id))
			.ForMember(vm => vm.DescPerfil, map => map.MapFrom(m => m.Perfil.DescPerfil));
		}
	}
}
