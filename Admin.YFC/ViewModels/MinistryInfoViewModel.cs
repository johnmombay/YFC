namespace Admin.YFC.ViewModels
{
	public class MinistryInfoViewModel
	{
		public int MinistryInfoId { get; set; }
		public int MinistryId { get; set; }
		public string? Ministry { get; set; }
		public string Content { get; set; } = default!;
	}
}
