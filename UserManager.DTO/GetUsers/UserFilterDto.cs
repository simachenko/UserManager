using System.Text.Json.Serialization;

namespace UserManager.DTO.GetUsers
{
	public class UserFilterDto
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("email")]
		public string Email { get; set; }

		[JsonPropertyName("role")]
		public string Role { get; set; }

		[JsonPropertyName("permissions")]
		public List<Guid> Permissions { get; set; }
	}
}
