using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.YFC.Common;
using Web.YFC.Models;
using Web.YFC.Services;

namespace Web.YFC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly HeadlineServices _headlineServices;
		private readonly TeachingServices _teachingServices;
		private readonly EventServices _eventServices;
		private readonly TestimonialServices _testimonialServices;
		private readonly ChurchServices _churchServices;
		private readonly PastorMessageServices _pastorMessageServices;
		private readonly ContentServices _contentServices;
		private readonly PastorServices _pastorServices;
		private readonly SectionServices _sectionServices;
		private readonly CommunityLeaderServices _communityLeaderServices;
		private readonly CommunityInfoServices _communityInfoServices;
		private readonly CommunityScheduleServices _communityScheduleServices;
		private readonly CommunityEventServices _communityEventServices;
		private readonly CommunityArticleServices _communityArticleServices;
		private readonly MinistryArticleServices _ministryArticleServices;
		private readonly MinistryEventServices _ministryEventServices;
		private readonly MinistryInfoServices _ministryInfoServices;
		private readonly MinistryLeaderServices _ministryLeaderServices;
		private readonly MinistryScheduleServices _ministryScheduleServices;
		private readonly CommunityServices _communityServices;
		private readonly MinistryServices _ministryServices;

		public HomeController(ILogger<HomeController> logger,
			HeadlineServices headlineServices,
			TeachingServices teachingServices,
			EventServices eventServices,
			TestimonialServices testimonialServices,
			ChurchServices churchServices,
			PastorMessageServices pastorMessageServices,
			ContentServices contentServices,
			PastorServices pastorServices,
			SectionServices sectionServices,
			CommunityLeaderServices communityLeaderServices,
			CommunityInfoServices communityInfoServices,
			CommunityEventServices communityEventServices,
			CommunityScheduleServices communityScheduleServices,
			CommunityArticleServices communityArticleServices,
			MinistryArticleServices ministryArticleServices,
			MinistryEventServices ministryEventServices,
			MinistryInfoServices ministryInfoServices,
			MinistryLeaderServices ministryLeaderServices,
			MinistryScheduleServices ministryScheduleServices,
			CommunityServices communityServices,
			MinistryServices ministryServices)
		{
			_logger = logger;
			_headlineServices = headlineServices;
			_teachingServices = teachingServices;
			_eventServices = eventServices;
			_testimonialServices = testimonialServices;
			_churchServices = churchServices;
			_pastorMessageServices = pastorMessageServices;
			_contentServices = contentServices;
			_pastorServices = pastorServices;
			_sectionServices = sectionServices;
			_communityLeaderServices = communityLeaderServices;
			_communityInfoServices = communityInfoServices;
			_communityScheduleServices = communityScheduleServices;
			_communityEventServices = communityEventServices;
			_communityArticleServices = communityArticleServices;
			_ministryArticleServices = ministryArticleServices;
			_ministryEventServices = ministryEventServices;
			_ministryInfoServices = ministryInfoServices;
			_ministryLeaderServices = ministryLeaderServices;
			_ministryScheduleServices = ministryScheduleServices;
			_communityServices = communityServices;
			_ministryServices = ministryServices;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.ImageUrl = AppSettings.ImageUrl;
			ViewData["Headlines"] = await _headlineServices.GetEnabledHeadlines();
			ViewData["Teachings"] = await _teachingServices.GetLatestTeachings();
			ViewData["Events"] = await _eventServices.GetEvents();
			ViewData["Testimonials"] = await _testimonialServices.GetTestimonials();
			ViewData["Churches"] = await _churchServices.GetChurches();
			
			var pastorMessages = await _pastorMessageServices.GetPastorMessages();

			if(pastorMessages.Count > 0)
			{
				ViewBag.Message = pastorMessages.FirstOrDefault()!.Message;

				var pastorId = pastorMessages.LastOrDefault()!.PastorId;
				var pastor = await _pastorServices.GetPastorById(pastorId);
				ViewBag.Pastor = pastor.Name;
				ViewBag.Title = pastorMessages.FirstOrDefault()!.Title;
				ViewBag.Signature = pastor.Signature;
				ViewBag.PastorId = pastorId;
			}

			return View();
		}

		public async Task<IActionResult> Event()
		{
			ViewData["Events"] = await _eventServices.GetEvents();

			return View();
		}

		public async Task<IActionResult> Community(int id)
		{
			ViewBag.Community = _communityServices.GetCommunityById(id).Result.Name;
			ViewBag.Information = _communityInfoServices.GetCommunityInfosByCommunityId(id).Result.Content;
			ViewData["Leaders"] = await _communityLeaderServices.GetCommunityLeadersByCommunityId(id);
			ViewData["Events"] = await _communityEventServices.GetCommunityEventsByCommunityId(id);
			ViewData["Schedules"] = await _communityScheduleServices.GetCommunitySchedulesByCommunityId(id);
			ViewData["Articles"] = await _communityArticleServices.GetCommunityArticlesByCommunityId(id);
			return View();
		}

		public async Task<IActionResult> Ministry(int id)
		{
			ViewBag.Ministry = _ministryServices.GetMinistryById(id).Result.Name;
			ViewBag.Information = _ministryInfoServices.GetMinistryInfoByMinistryId(id).Result.Content;
			ViewData["Leaders"] = await _ministryLeaderServices.GetMinistryLeadersByMinistryId(id);
			ViewData["Events"] = await _ministryEventServices.GetMinistryEventsByMinistryId(id);
			ViewData["Schedules"] = await _ministryScheduleServices.GetMinistrySchedulesByMinistryId(id);
			ViewData["Articles"] = await _ministryArticleServices.GetMinistryArticlesByMinistryId(id);
			return View();
		}

		public async Task<IActionResult> Content(int id)
		{
			var content = await _contentServices.GetContentById(id);
			var section = await _sectionServices.GetSectionById(content.SectionId);
			ViewBag.Section = section.Name;
			return View(content);
		}

		public async Task<IActionResult> Teaching()
		{
			ViewData["Teachings"] = await _teachingServices.GetTeachings();
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
