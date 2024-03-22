using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Infrastructure.Extentions
{
	internal static class Extentions
	{
		public static IdentityResult ThrowIfNotSuccess(this IdentityResult identityResult)
		{
			if (!identityResult.Succeeded)
			{
				throw new Exception($"Failed to mutate user with following errors: {string.Join(",", identityResult.Errors.Select(e => $"{e.Code} {e.Description}"))}");
			}
			return identityResult;
		}
	}
}
