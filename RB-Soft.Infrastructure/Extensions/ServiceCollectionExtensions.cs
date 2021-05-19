using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using RB_Soft.Data.Context;
using RB_Soft.Infrastructure.Extensions.Services;

namespace RB_Soft.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
		{
			services.AddRepositories();

			return services;
		}

		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
		{
			services
				.AddEntityFrameworkSqlServer()
				.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

			return services;
		}
	}
}
