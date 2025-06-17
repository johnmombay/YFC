namespace Admin.YFC.ViewModels
{
	public class CommunityArticleViewModel
	{
		public int CommunityArticleId { get; set; }
		public int CommunityId { get; set; }
		public string? Community { get; set; }
		public string Title { get; set; } = default!;
		public string Content { get; set; } = default!;
	}
}
