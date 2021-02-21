using AutoMapper;

namespace DBCorp.ControleAcesso.API.AutoMapper
{
	public class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.Initialize(x =>
			{
				x.AddProfile<DomainToViewModel.UsuarioMappingProfile>();
				x.AddProfile<ViewModelToDomain.UsuarioMappingProfile>();

				x.AddProfile<DomainToViewModel.MenuMappingProfile>();
				x.AddProfile<ViewModelToDomain.MenuMappingProfile>();
			});
		}
	}
}
