namespace Web.YFC.Models
{
	public class CommunityInfo
	{
		public int CommunityInfoId { get; set; }
		public int CommunityId { get; set; }
		public Community? Community { get; set; }
		public string About { get; set; } = default!;
		public string Leaders { get; set; } = default!;
		public string? News { get; set; }
		public string? Calendar { get; set; }
	}
}
