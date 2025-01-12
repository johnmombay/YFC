namespace Api.YFC.Models
{
	public class Content
	{
		public int ContentId { get; set; }
		public int SectionId { get; set; }
		public Section? Section { get; set; }
		public string Material { get; set; } = default!;
	}
}
