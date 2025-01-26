namespace Web.YFC.Models
{
	public class CommunityLeader
	{
		public int CommunityLeaderId { get; set; }
		public int CommunityId { get; set; }
		public Community? Community { get; set; }
		public string Name { get; set; } = default!;
		public string? Email { get; set; }
	}
}
