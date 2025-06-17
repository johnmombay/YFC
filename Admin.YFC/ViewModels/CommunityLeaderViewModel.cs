namespace Admin.YFC.ViewModels
{
	public class CommunityLeaderViewModel
	{
		public int CommunityLeaderId { get; set; }
		public int CommunityId { get; set; }
		public string? Community { get; set; }
		public string Name { get; set; } = default!;
		public string? Email { get; set; }
	}
}
