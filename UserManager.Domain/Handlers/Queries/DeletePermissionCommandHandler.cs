using MediatR;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Requests;
using UserManager.Domain.Models.Permissions;

namespace UserManager.Domain.Handlers.Queries
{
	internal class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand>
	{
		private readonly IPermissionsRepository _repository;

		public DeletePermissionCommandHandler(IPermissionsRepository repository)
		{
			_repository = repository;
		}

		public Task Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
		{
			return _repository.DeletePermission(request.Id);
		}
	}
}
