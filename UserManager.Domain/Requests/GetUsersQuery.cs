using MediatR;
using UserManager.Domain.Models.GetModels;

namespace UserManager.Domain.Requests
{
	public class GetUsersQuery : GetUsersModel, IRequest<List<GetUserResult>>
	{
	}
}
