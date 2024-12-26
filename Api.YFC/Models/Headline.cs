using System.Net.NetworkInformation;

namespace Api.YFC.Models
{
	public class Headline
	{
		public int HeadlineId {  get; set; }
		public string Title {  get; set; } = default!;
		public string Subtitle { get; set; } = default!;
		public string? Description { get; set; }
		public string Url { get; set; } = default!;
		public bool Enable {  get; set; }
	}
}
