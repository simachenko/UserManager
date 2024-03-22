namespace UserManager.Domain.Models.GetModels
{
	public class UserFilter
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }
		public List<Guid> Permissions { get; set; }
	}
}
