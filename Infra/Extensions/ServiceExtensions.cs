using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RentToParty.Infra.AutoMapper;

namespace RentToParty.Infra.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterWebAPIServices(this IServiceCollection services)
        {
            
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));


            return services;
        }
    }
}
