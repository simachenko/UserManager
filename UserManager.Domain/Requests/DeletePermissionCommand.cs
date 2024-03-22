using MediatR;
using UserManager.Domain.Models.Permissions;

namespace UserManager.Domain.Requests
{
	public class DeletePermissionCommand : IRequest
	{
		public Guid? Id { get; set; }
	}
}
