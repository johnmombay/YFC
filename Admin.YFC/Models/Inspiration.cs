namespace Admin.YFC.Models
{
	public class Inspiration
	{
		public int InsipirationId { get; set; }
		public string Title { get; set; } = default!;
		public string Message { get; set; } = default!;
		public string Author { get; set; } = default!;
	}
}
