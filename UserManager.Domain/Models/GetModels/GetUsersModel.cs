namespace UserManager.Domain.Models.GetModels
{
	public class GetUsersModel
	{
		public UserFilter Filter { set; get; }
		public Pagination Pagination { set; get; }
		public List<Ordering> Ordering { set; get; }
	}

	public class Pagination
	{
		public int? Skip { get; set; }
		public int? Take { get; set; }
	}
}
