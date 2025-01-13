
namespace Api.YFC.Models
{
	public class MinistryArticle
	{
		public int MinistryArticleId { get; set; }
		public int MinistryId { get; set; }
		public Ministry? Ministry { get; set; }
		public string Title { get; set; } = default!;
		public string Content { get; set; } = default!;
	}
}
