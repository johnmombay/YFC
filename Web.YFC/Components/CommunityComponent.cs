using Microsoft.AspNetCore.Mvc;
using Web.YFC.Services;

namespace Web.YFC.Components
{
	public class CommunityComponent : ViewComponent
	{
		private readonly CommunityServices _communityServices;

		public CommunityComponent(CommunityServices communityServices)
		{
			_communityServices = communityServices;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var communities = await _communityServices.GetCommunities();
			return View(communities);
		}
	}
}
