namespace Api.YFC.ViewModels
{
	public class ChangePasswordViewModel
	{
		public string Id { get; set; } = default!;
		public string CurrentPassword { get; set; } = default!;
		public string NewPassword { get; set; } = default!;
	}
}
