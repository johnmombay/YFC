namespace Web.YFC.Models
{
	public class MinistryLeader
	{
		public int MinistryLeaderId { get; set; }
		public int MinistryId { get; set; }
		public Ministry? Ministry { get; set; }
		public string Name { get; set; } = default!;
		public string? Email { get; set; }
	}
}
