namespace UserManager.Infrastructure.DataAccess.Models
{
	public class PermissionDb
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<UserDb> Users { get; set; }
	}
}
