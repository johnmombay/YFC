namespace Admin.YFC.Models
{
	public class MinistryInfo
	{
		public int MinistryInfoId { get; set; }
		public int MinistryId { get; set; }
		public Ministry? Ministry { get; set; }
		public string Content { get; set; } = default!;
	}
}
