using System.Text.Json.Serialization;

namespace UserManager.DTO.Permissions
{
	public class CreatePermissionDto
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }
	}
}
