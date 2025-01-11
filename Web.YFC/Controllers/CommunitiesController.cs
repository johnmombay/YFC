using Microsoft.AspNetCore.Mvc;
using Web.YFC.Services;

namespace Web.YFC.Controllers
{
	public class CommunitiesController : Controller
	{
		private readonly CommunityInfoServices _communityInfoServices;

		public CommunitiesController(CommunityInfoServices communityInfoServices)
		{
			_communityInfoServices = communityInfoServices;
		}

		public async Task<IActionResult> Index(int id)
		{
			var community = await _communityInfoServices.GetCommunityInfoByCommunityId(id);
			return View(community);
		}
	}
}
