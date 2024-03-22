using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using UserManager.Infrastructure.DataAccess.Models;
using UserManager.Infrastructure.DataAccess.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UserManager.Infrastructure.DataAccess
{
	internal class UserManagerContext : IdentityDbContext<UserDb>
	{
		private readonly DBOptions _options;
		public UserManagerContext(IOptions<DBOptions> options)
		{
			_options = options?.Value;
			if (string.IsNullOrEmpty(_options?.ConnectionString)) throw new ArgumentNullException($"{nameof(UserManagerContext)} - null/empty {nameof(DBOptions)}.{nameof(DBOptions.ConnectionString)}");
		}

		public DbSet<PermissionDb> Permissions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			if (!string.IsNullOrEmpty(_options?.Schema))
			{
				modelBuilder.HasDefaultSchema(_options.Schema);
			}

			modelBuilder.Entity<UserDb>()
				.ToTable("Users")
				.HasMany(x => x.Permissions)
				.WithMany(x => x.Users);
			modelBuilder.Entity<PermissionDb>()
				.ToTable("Permissions")
				.HasMany(x => x.Users)
				.WithMany(x => x.Permissions);
			modelBuilder.Entity<PermissionDb>()
				.HasData(DefaultPermissions.Permissions);
			
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			if (string.IsNullOrEmpty(_options?.ConnectionString)) throw new ArgumentNullException($"{nameof(UserManagerContext)} - null/empty {nameof(DBOptions)}.{nameof(DBOptions.ConnectionString)}");

			optionsBuilder.EnableDetailedErrors();
			optionsBuilder.UseSqlServer(_options?.ConnectionString, sqlOptions =>
			{
				sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
			})
			.EnableSensitiveDataLogging()
			.EnableDetailedErrors()
			.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
		}
	}

	internal class UserManagerContextFactory : IDesignTimeDbContextFactory<UserManagerContext>
	{
		public UserManagerContext CreateDbContext(string[] args)
		{
			var connstring = args[0];
			var schema = args[1];

			return new UserManagerContext(new OptionsWrapper<DBOptions>(new DBOptions()
			{
				ConnectionString = new SqlConnectionStringBuilder(connstring).ConnectionString,
				Schema = schema,
			}));
		}
	}
}
