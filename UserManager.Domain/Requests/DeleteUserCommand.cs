using MediatR;
using UserManager.Domain.Models.GetModels;
using UserManager.Domain.Models.UpdateModels;

namespace UserManager.Domain.Requests
{
	public class DeleteUserCommand : IRequest<GetUserResult>
	{
		public Guid Id { get; set; }
	}
}
