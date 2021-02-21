using AutoMapper;

namespace DBCorp.CRM.API.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModel.FunilMappingProfile>();
                x.AddProfile<ViewModelToDomain.FunilMappingProfile>();
 
            });
        }
    }
}
