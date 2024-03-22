using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UserManager.Domain;
using UserManager.Domain.Converter;
using UserManager.Domain.Interfaces;
using UserManager.Infrastructure.DataAccess;
using UserManager.Infrastructure.DataAccess.Models;
using UserManager.Infrastructure.DataAccess.Options;
using UserManager.Infrastructure.DataAccess.Repos;
namespace UserManager
{
	public static class DI
	{
		public static IServiceCollection AddUserManagerServicesDb(this IServiceCollection services)
		{
			services.AddDbContext<UserManagerContext>();
			services.AddSingleton<IConfigureOptions<DBOptions>, UserManagerContextConfigureOptions>();
			services.AddIdentityCore<UserDb>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<UserManagerContext>().AddDefaultTokenProviders();
			services.AddDataProtection();
			return services;
		}

		public static IServiceCollection AddUserManagerServices(this IServiceCollection services)
		{
			services.AddUserManagerDomainServices();
			services.AddUserManagerServicesDb();
			services.AddAutoMapper(x => x.AddProfile<ConvertingProfile>());
			services.AddScoped<IUserManagerRepository, UserManagerRepository>();
			services.AddScoped<IPermissionsRepository, PermissionsRepository>();
			return services;
		}
	}
}
