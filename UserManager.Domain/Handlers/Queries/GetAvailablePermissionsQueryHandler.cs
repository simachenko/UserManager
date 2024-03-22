using MediatR;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Requests;
using UserManager.Domain.Models.Permissions;

namespace UserManager.Domain.Handlers.Queries
{
	internal class GetAvailablePermissionsQueryHandler : IRequestHandler<GetAvailablePermissionsQuery, List<Permission>>
	{
		private readonly IPermissionsRepository _repository;

		public GetAvailablePermissionsQueryHandler(IPermissionsRepository repository)
		{
			_repository = repository;
		}

		public Task<List<Permission>> Handle(GetAvailablePermissionsQuery request, CancellationToken cancellationToken)
		{
			return _repository.GetAvailablePermissions();
		}
	}
}
