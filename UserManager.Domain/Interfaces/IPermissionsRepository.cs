using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Models.Permissions;
using UserManager.Domain.Requests;

namespace UserManager.Domain.Interfaces
{
	public interface IPermissionsRepository
	{
		Task<Permission> CreatePermission(Permission request);
		Task DeletePermission(Guid? id);
		Task<List<Permission>> GetAvailablePermissions();
	}
}
