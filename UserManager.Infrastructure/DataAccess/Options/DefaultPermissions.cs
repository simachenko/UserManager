using UserManager.Infrastructure.DataAccess.Models;

namespace UserManager.Infrastructure.DataAccess.Options
{
	internal static class DefaultPermissions
	{
		public static List<PermissionDb> Permissions => new List<PermissionDb>
		{
			new(){ Id = Guid.NewGuid(), Name = "Read"},
			new(){ Id = Guid.NewGuid(), Name = "Write"},
			new(){ Id = Guid.NewGuid(), Name = "ReadWrite"},
			new(){ Id = Guid.NewGuid(), Name = "Move"},
		};
	}
}
