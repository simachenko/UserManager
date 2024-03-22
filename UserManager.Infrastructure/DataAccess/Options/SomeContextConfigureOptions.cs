using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace UserManager.Infrastructure.DataAccess.Options
{
	internal class UserManagerContextConfigureOptions : IConfigureOptions<DBOptions>
	{
		private readonly IConfiguration _configuration;

		public UserManagerContextConfigureOptions(IConfiguration configuration)
		{
			this._configuration = configuration;
		}

		public void Configure(DBOptions options)
		{
			if (options.ConnectionString == null)
			{
				options.ConnectionString =
					new SqlConnectionStringBuilder(_configuration.GetConnectionString("Connection"))
					{
						Password = _configuration["ConnectionDbPassword"],
						MultiSubnetFailover = true,
						ConnectTimeout = 1000
					}.ConnectionString;
			}
		}
	}
}
