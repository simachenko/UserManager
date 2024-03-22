using MediatR;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Models.GetModels;
using UserManager.Domain.Models.UpdateModels;
using UserManager.Domain.Requests;

namespace UserManager.Domain.Handlers.Commands
{
	internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, GetUserResult>
	{
		private readonly IUserManagerRepository _repository;

		public DeleteUserCommandHandler(IUserManagerRepository repository)
		{
			_repository = repository;
		}

		public Task<GetUserResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			return _repository.DeleteUser(request.Id); // maybe should use soft delete
		}
	}

	
}
