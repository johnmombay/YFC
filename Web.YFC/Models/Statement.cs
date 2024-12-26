namespace Web.YFC.Models
{
	public class Statement
	{
		public int StatementId { get; set; }
		public string Message { get; set; } = default!;
		public string Author { get; set; } = default!;
	}
}
