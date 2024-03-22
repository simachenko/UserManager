using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Models.CreateModels;
using UserManager.Domain.Models.GetModels;
using UserManager.Domain.Models.UpdateModels;
using UserManager.Domain.Requests;

namespace UserManager.Domain.Interfaces
{
	public interface IUserManagerRepository
	{
		Task<GetUserResult> CreateUser(CreateUserModel request);
		Task<GetUserResult> DeleteUser(Guid id);
		Task<GetUserResult> UpdateUser(UpdateUserModel request);
		Task<List<GetUserResult>> GetUsers(GetUsersModel getUsersModel);
	}
}
