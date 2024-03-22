using MediatR;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Models.CreateModels;
using UserManager.Domain.Models.GetModels;
using UserManager.Domain.Requests;

namespace UserManager.Domain.Handlers.Commands
{
	internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, GetUserResult>
	{
		private readonly IUserManagerRepository _repository;

		public CreateUserCommandHandler(IUserManagerRepository repository)
		{
			_repository = repository;
		}

		public Task<GetUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			return _repository.CreateUser(request);
		}
	}

	
}
