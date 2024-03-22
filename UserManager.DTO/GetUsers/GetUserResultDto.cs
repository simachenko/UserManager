using System.Text.Json.Serialization;
using UserManager.DTO.Permissions;

namespace UserManager.DTO.GetUsers
{
	public class GetUserResultDto
	{
		[JsonPropertyName("id")]
		public Guid Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("email")]
		public string Email { get; set; }

		[JsonPropertyName("role")]
		public string Role { get; set; }

		[JsonPropertyName("permissions")]
		public List<GetPermissionResultDto> Permissions { get; set; }
	}
}
