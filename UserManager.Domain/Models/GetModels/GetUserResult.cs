using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Domain.Models.GetModels
{
	public class GetUserResult
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }
		public List<GetPermissionResultModel> Permissions { set; get; }
	}
}
