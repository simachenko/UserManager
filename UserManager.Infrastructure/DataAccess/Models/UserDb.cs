﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Infrastructure.DataAccess.Models
{
	public class UserDb : IdentityUser
	{
		public List<PermissionDb> Permissions { get; set; }
	}
}
