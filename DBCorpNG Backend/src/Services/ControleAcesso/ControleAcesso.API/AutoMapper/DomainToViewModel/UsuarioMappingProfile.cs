using AutoMapper;
using DBCorp.ControleAcesso.API.ViewModel;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.API.AutoMapper.DomainToViewModel
{
	public class UsuarioMappingProfile : Profile
	{
		public UsuarioMappingProfile()
		{
			CreateMap<Usuario, UsuarioViewModel>()
			.ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id))
			.ForMember(vm => vm.Username, map => map.MapFrom(m => m.Username))
			.ForMember(vm => vm.PrimeiroNome, map => map.MapFrom(m => m.PrimeiroNome))
			.ForMember(vm => vm.UltimoNome, map => map.MapFrom(m => m.UltimoNome))
			.ForMember(vm => vm.Token, map => map.MapFrom(m => m.Token));
		}
	}
}
