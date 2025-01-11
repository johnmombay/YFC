namespace Admin.YFC.Models
{
	public class MinistryInfo
	{
		public int MinistryInfoId { get; set; }
		public int MinistryId { get; set; }
		public Ministry? Ministry { get; set; }
		public string About { get; set; } = default!;
		public string Leaders { get; set; } = default!;
		public string? News { get; set; }
		public string? Calendar { get; set; }
	}
}
