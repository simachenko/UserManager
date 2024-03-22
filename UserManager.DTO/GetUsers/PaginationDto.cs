using System.Text.Json.Serialization;

namespace UserManager.DTO.GetUsers
{
	public class PaginationDto
	{
		[JsonPropertyName("skip")]
		public int? Skip { get; set; }

		[JsonPropertyName("take")]
		public int? Take { get; set; }
	}
}
