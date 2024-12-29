using Admin.YFC.Models;
using Admin.YFC.Services;
using Admin.YFC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin.YFC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly UserServices _userServices;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public HomeController(ILogger<HomeController> logger,
			UserServices userServices,
			SignInManager<ApplicationUser> signInManager)
		{
			_logger = logger;
			_userServices = userServices;
			_signInManager = signInManager;
		}

		public IActionResult Index()
		{
			if(!User.Identity!.IsAuthenticated)
			{
				return RedirectToAction("Login", "Home");
			}
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login([Bind("Email,Password,RememberMe")] LoginViewModel login)
		{
			var user = await _userServices.CheckCredentials(login);
			if (user.Email == login.Email)
			{
				await _signInManager.SignInAsync(user, isPersistent: login.RememberMe);
				return RedirectToAction("Index", "Home");
			}
			return View(login);
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register([Bind("Firstname,Lastname,Email,Password")] RegisterViewModel register)
		{
			register.Role = "None";
			var result = await _userServices.AddUser(register);
			if (result)
			{
				return RedirectToAction("Login", "Home");
			}
			return View(register);
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login", "Home");
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
