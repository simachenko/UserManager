using Microsoft.Extensions.DependencyInjection;

namespace UserManager.Domain
{
	public static class DI
	{
		public static IServiceCollection AddUserManagerDomainServices(this IServiceCollection services)
		{
			services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssembly(typeof(DI).Assembly);
			});
			return services;
		}
	}
}
