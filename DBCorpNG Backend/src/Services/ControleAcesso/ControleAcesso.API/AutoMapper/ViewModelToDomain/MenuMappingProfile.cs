using AutoMapper;
using DBCorp.ControleAcesso.API.ViewModel;
using DBCorp.ControleAcesso.Domain.Model;

namespace DBCorp.ControleAcesso.API.AutoMapper.ViewModelToDomain
{
	public class MenuMappingProfile : Profile
	{
		public MenuMappingProfile()
		{
			CreateMap<MenuViewModel, Menu>();
		}
	}
}
