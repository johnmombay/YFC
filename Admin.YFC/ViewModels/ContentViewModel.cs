namespace Admin.YFC.ViewModels
{
	public class ContentViewModel
	{
		public int ContentId { get; set; }
		public int SectionId { get; set; }
		public string? Section { get; set; }
		public string Material { get; set; } = default!;
	}
}
