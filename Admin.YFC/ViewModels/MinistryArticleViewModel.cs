namespace Admin.YFC.ViewModels
{
	public class MinistryArticleViewModel
	{
		public int MinistryArticleId { get; set; }
		public int MinistryId { get; set; }
		public string? Ministry { get; set; }
		public string Title { get; set; } = default!;
		public string Content { get; set; } = default!;
	}
}
