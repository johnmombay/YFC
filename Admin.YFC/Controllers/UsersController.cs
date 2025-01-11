using Admin.YFC.Common;
using Admin.YFC.Models;
using Admin.YFC.Services;
using Admin.YFC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

		[HttpPost]
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
			ViewBag.Id = id;
			ViewBag.Email = user.Email;
			return View(user);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string id, [Bind("Id,Firstname,Lastname,Email")] ApplicationUser user)
		{
			if (ModelState.IsValid)
			{
				await _userServices.UpdateUser(user);
				return RedirectToAction("Index");
			}
			return View(user);
		}

		public async Task<IActionResult> Remove(string id)
		{
			var user = await _userServices.GetUser(id);
			ViewBag.Id = id;
			ViewBag.Email = user.Email;
			return View(user);
		}

		public async Task<IActionResult> Delete(string id)
		{
			await _userServices.RemoveUser(id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> UpdateRole(string id)
		{
			var user = await _userServices.GetUser(id);
			ViewBag.Id = id;
			var role = await _userServices.GetRole(id);
			ViewBag.Role = new SelectList(new List<string> { "None", "Administrator", "Content Manager", "Community Leader", "Ministry Leader" }, role);
			var changeRoleViewModel = new ChangeRoleViewModel()
			{
				Id = id,
				NewRole = role,
			};
			return View(changeRoleViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateRole(string id, string newRole)
		{
			await _userServices.UpdateRole(id, newRole);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> GetRole(string id)
		{
			var role = await _userServices.GetRole(id);
			return Json(new { data = role });
		}

		public async Task<IActionResult> ResetPassword(string id)
		{
			var user = await _userServices.GetUser(id);
			ViewBag.Id = id;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
		{
			await _userServices.ResetPassword(resetPasswordViewModel);
			return RedirectToAction("Index");
		}
	}
}
