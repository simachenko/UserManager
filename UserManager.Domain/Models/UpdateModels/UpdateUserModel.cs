namespace UserManager.Domain.Models.UpdateModels
{
	public class UpdateUserModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public List<Guid> Permissions { set; get; }
	}

}
