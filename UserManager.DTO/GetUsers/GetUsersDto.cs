using System.Text.Json.Serialization;

namespace UserManager.DTO.GetUsers
{
	public class GetUsersDto
	{
		[JsonPropertyName("filter")]
		public UserFilterDto Filter { get; set; }

		[JsonPropertyName("pagination")]
		public PaginationDto Pagination { get; set; }

		[JsonPropertyName("ordering")]
		public List<OrderingDto> Ordering { get; set; }
	}
}
