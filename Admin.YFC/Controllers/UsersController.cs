using Admin.YFC.Models;
using Admin.YFC.Services;
using Admin.YFC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class UsersController : Controller
	{
		private readonly UserServices _userServices;

		public UsersController(UserServices userServices)
		{
			_userServices = userServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetUsers()
		{
			var users = await _userServices.GetUsers();
			return Json(new { data = users });
		}

		public IActionResult Create()
		{
			return View();
		}

		public async Task<IActionResult> Create([Bind("Firstname,Lastname,Email,Password,Role")] RegisterViewModel register)
		{
			if (ModelState.IsValid)
			{
				await _userServices.AddUser(register);
				return RedirectToAction("Index");
			}
			return View(register);
		}

		public async Task<IActionResult> Edit(string id)
		{
			var user = await _userServices.GetUser(id);
			return View(user);
		}

		public async Task<IActionResult> Edit(string id, [Bind("Id,Firstname,Lastname,Email")] ApplicationUser user)
		{
			if (ModelState.IsValid)
			{
				await _userServices.UpdateUser(user);
				return RedirectToAction("Index");
			}
			return View(user);
		}		
	}
}
