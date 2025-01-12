namespace Web.YFC.Models
{
	public class PastorMessage
	{
		public int PastorMessageId { get; set; }
		public string Title { get; set; } = default!;
		public string Message { get; set; } = default!;
		public int PastorId { get; set; }
		public Pastor? Pastor { get; set; }
	}
}
