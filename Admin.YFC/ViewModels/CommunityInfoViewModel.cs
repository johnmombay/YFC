namespace Admin.YFC.ViewModels
{
	public class CommunityInfoViewModel
	{
		public int CommunityInfoId { get; set; }
		public int CommunityId { get; set; }
		public string? Community { get; set; }
		public string Content { get; set; } = default!;
	}
}
