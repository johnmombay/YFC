namespace Admin.YFC.Models
{
	public class CommunityArticle
	{
		public int CommunityArticleId { get; set; }
		public int CommunityId { get; set; }
		public Community? Community { get; set; }
		public string Title { get; set; } = default!;
		public string Content { get; set; } = default!;
	}
}
