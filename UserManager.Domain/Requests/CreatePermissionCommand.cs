using MediatR;
using UserManager.Domain.Models.Permissions;

namespace UserManager.Domain.Requests
{
	public class CreatePermissionCommand : Permission, IRequest<Permission>
	{
	}
}
