using System.Text.Json.Serialization;

namespace UserManager.DTO.Permissions
{
	public class GetPermissionResultDto
	{
		[JsonPropertyName("id")]
		public Guid? Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }
	}
}
