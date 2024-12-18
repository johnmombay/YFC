namespace Api.YFC.Models
{
	public class Statement
	{
		public int StatementId { get; set; }
		public string Author { get; set; } = default!;
		public string Message { get; set; } = default!;
	}
}
