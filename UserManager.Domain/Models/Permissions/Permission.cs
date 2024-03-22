using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Domain.Models.Permissions
{
	public class Permission
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
	}
}
