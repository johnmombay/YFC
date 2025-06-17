namespace Admin.YFC.ViewModels
{
	public class MinistryLeaderViewModel
	{
		public int MinistryLeaderId { get; set; }
		public int MinistryId { get; set; }
		public string? Ministry { get; set; }
		public string Name { get; set; } = default!;
		public string? Email { get; set; }
	}
}
