using AutoMapper;
using DBCorp.ControleAcesso.API.ViewModel;
using DBCorp.ControleAcesso.Domain.Model;

namespace DBCorp.ControleAcesso.API.AutoMapper.DomainToViewModel
{
	public class MenuMappingProfile : Profile
	{
		public MenuMappingProfile()
		{
			CreateMap<Menu, MenuViewModel>()
				.ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id));
		}
	}
}
