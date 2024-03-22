using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Models.Permissions;

namespace UserManager.Domain.Requests
{
	public class GetAvailablePermissionsQuery : IRequest<List<Permission>>
	{
	}
}
