using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UserManager.DTO.Permissions;

namespace UserManager.DTO.MutateUser
{
	public class MutateUserDto
	{
		[JsonPropertyName("id")]
		public Guid? Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email format")]
		[JsonPropertyName("email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[JsonPropertyName("password")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Role is required")]
		[JsonPropertyName("role")]
		public string Role { get; set; }

		[JsonPropertyName("permissions")]
		public List<Guid> Permissions { get; set; }
	}
}
