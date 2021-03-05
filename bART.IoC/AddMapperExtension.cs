using AutoMapper;
using bART.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace bART.IoC
{
    public static class AddMapperExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServicesMapperProfile());
                mc.AddProfile(new WebAPIMapperProfile());
                mc.AllowNullCollections = true;
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
