using System.Text.Json.Serialization;

namespace UserManager.DTO.GetUsers
{
	public class OrderingDto
	{
		[JsonPropertyName("orderType")]
		public FilterTypeDto OrderType { get; set; }

		[JsonPropertyName("descending")]
		public bool Descending { get; set; }
	}
}
