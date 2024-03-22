using MediatR;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Requests;
using UserManager.Domain.Models.Permissions;

namespace UserManager.Domain.Handlers.Queries
{
	internal class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, Permission>
	{
		private readonly IPermissionsRepository _repository;

		public CreatePermissionCommandHandler(IPermissionsRepository repository)
		{
			_repository = repository;
		}

		public Task<Permission> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
		{
			return _repository.CreatePermission(request);
		}
	}
}
