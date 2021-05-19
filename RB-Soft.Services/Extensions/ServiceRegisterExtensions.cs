using AutoMapper;

using Microsoft.Extensions.DependencyInjection;

using RB_Soft.Infrastructure.Extensions;
using RB_Soft.Infrastructure.Mapper;

namespace RB_Soft.Services.Extensions
{
    public static class ServiceRegisterExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.ConfigureRepositories();

            //services.AddTransient<ITransactionService, TransactionService>();

            services.AddMapper();

            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var dataProfiles = MappingProfile.GetDataProfiles();
            
            var config = new MapperConfiguration(cfg =>
            {
                dataProfiles.ForEach(p => cfg.AddProfile(p));
                //cfg.AddProfile(new IncidentModelProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
