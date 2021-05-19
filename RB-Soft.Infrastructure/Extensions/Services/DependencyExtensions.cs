using Microsoft.Extensions.DependencyInjection;

using RB_Soft.Data.Core;
using RB_Soft.Infrastructure.Services;
using RB_Soft.Infrastructure.Services.Implementation;

namespace RB_Soft.Infrastructure.Extensions.Services
{
    internal static class DependencyExtensions
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IDatabaseTransaction, DatabaseTransaction>();
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddScoped<IDetailService, DetailService>();

			return services;
		}
	}
}
