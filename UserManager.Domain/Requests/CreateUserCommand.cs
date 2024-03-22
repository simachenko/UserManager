using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Models.CreateModels;
using UserManager.Domain.Models.GetModels;

namespace UserManager.Domain.Requests
{
	public class CreateUserCommand : CreateUserModel, IRequest<GetUserResult>
	{
	}
}
