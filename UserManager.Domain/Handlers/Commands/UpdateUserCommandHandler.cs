using MediatR;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Models.GetModels;
using UserManager.Domain.Models.UpdateModels;
using UserManager.Domain.Requests;

namespace UserManager.Domain.Handlers.Commands
{
	internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GetUserResult>
	{
		private readonly IUserManagerRepository _repository;

		public UpdateUserCommandHandler(IUserManagerRepository repository)
		{
			_repository = repository;
		}

		public Task<GetUserResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			return _repository.UpdateUser(request);
		}
	}
	
}
