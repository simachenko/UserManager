using MediatR;
using UserManager.Domain.Models.GetModels;
using UserManager.Domain.Models.UpdateModels;

namespace UserManager.Domain.Requests
{
	public class UpdateUserCommand : UpdateUserModel, IRequest<GetUserResult>
	{
	}
}
