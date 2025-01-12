namespace Admin.YFC.Models
{
	public class Community
	{
		public int CommunityId { get; set; }
		public string Name { get; set; } = default!;
		public bool Enabled { get; set; }
	}
}
