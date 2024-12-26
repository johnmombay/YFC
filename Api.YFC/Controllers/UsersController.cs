using Api.YFC.Data;
using Api.YFC.Models;
using Api.YFC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.YFC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ApplicationDbContext _context;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ILogger<UsersController> _logger;

		public UsersController(UserManager<ApplicationUser> userManager,
			ApplicationDbContext context,
			RoleManager<IdentityRole> roleManager,
			ILogger<UsersController> logger)
		{
			_userManager = userManager;
			_context = context;
			_roleManager = roleManager;
			_logger = logger;
		}

		[HttpGet]
		public async Task<ActionResult> GetUser()
		{
			try
			{
				List<UserViewModel> userViewModel = new List<UserViewModel>();
				var users = await _context.ApplicationUsers.ToListAsync();

				foreach (var user in users)
				{
					var role = await _userManager.GetRolesAsync(user);
					userViewModel.Add(new UserViewModel
					{
						Id = user.Id,
						Firstname = user.Firstname,
						Lastname = user.Lastname,
						Email = user.Email!,
						Role = role[0]
					});
				}
				return Ok(userViewModel);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Get Users (UsersController) : " + ex.HResult + " - " + ex.Message);
				return NoContent();
			}
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult> GetUser(string id)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(id);
				return Ok(user);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Get User by Id (UsersController) : " + ex.HResult + " - " + ex.Message);
				return NoContent();
			}
		}

		[HttpGet]
		[Route("ByEmail/{email}")]
		public async Task<ActionResult> GetUserByEmail(string email)
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(email);
				var role = await _userManager.GetRolesAsync(user!);

				var userViewModel = new UserViewModel()
				{
					Id = user!.Id,
					Firstname = user.Firstname,
					Lastname = user.Lastname,
					Email = user.Email!,
					Role = role[0]
				};
				return Ok(userViewModel);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Get User by Email Address (UsersController) : " + ex.HResult + " - " + ex.Message);
				return NoContent();
			}
		}

		[HttpPost]
		[Route("Register")]
		public async Task<ActionResult> AddUser(RegisterViewModel register)
		{
			try
			{
				var user = new ApplicationUser()
				{
					UserName = register.Email,
					Email = register.Email,
					Firstname = register.Firstname,
					Lastname = register.Lastname,
					EmailConfirmed = true
				};

				var result = await _userManager.CreateAsync(user, register.Password);
				if (result.Succeeded)
				{
					if (!await _roleManager.RoleExistsAsync(register.Role))
					{
						await _roleManager.CreateAsync(new IdentityRole(register.Role));
					}
					await _userManager.AddToRoleAsync(user, register.Role);
					return Ok(true);
				}
				return BadRequest(false);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Add User (UsersController) : " + ex.HResult + " - " + ex.Message);
				return NoContent();
			}
		}

		[HttpPut]
		[Route("Update")]
		public async Task<ActionResult> UpdateUser([Bind("Id,FirstName,MiddleName,LastName,IsEnabled,IsDeleted")] ApplicationUser applicationUser)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(applicationUser.Id);
				if (user != null)
				{
					user.Firstname = applicationUser.Firstname;
					user.Lastname = applicationUser.Lastname;

					_context.Update(user);
					await _context.SaveChangesAsync();

					user = await _userManager.FindByIdAsync(applicationUser.Id);
					return Ok(user);
				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Update User (UsersController) : " + ex.HResult + " - " + ex.Message);
				return NoContent();
			}
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public async Task<ActionResult> DeleteUser(string id)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(id);
				_context.Remove(user);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Delete User (UsersController) : " + ex.HResult + " - " + ex.Message);
				return BadRequest();
			}
		}

		[HttpGet]
		[Route("GetByRole/{role}")]
		public async Task<ActionResult> GetUserByRole(string role)
		{
			try
			{
				var users = _userManager.Users.ToList();
				var userList = new List<ApplicationUser>();
				foreach (var user in users)
				{
					var userRole = await _userManager.GetRolesAsync(user);
					if (userRole[0].ToUpper() == role.ToUpper())
					{
						userList.Add(user);
					}
				}
				return Ok(userList);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Get User by Role (UsersController) : " + ex.HResult + " - " + ex.Message);
				return BadRequest();
			}
		}

		[HttpGet]
		[Route("GetRole/{id}")]
		public async Task<ActionResult> GetUserRole(string id)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(id);
				var role = await _userManager.GetRolesAsync(user!);
				return Ok(role[0]);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Get User's Role (UsersController) : " + ex.HResult + " - " + ex.Message);
				return BadRequest();
			}
		}

		[HttpPost]
		[Route("UpdateRole")]
		public async Task<ActionResult> UpdateUserRole(ChangeRoleViewModel changeRole)
		{
			try
			{
				if (!await _roleManager.RoleExistsAsync(changeRole.NewRole))
				{
					await _roleManager.CreateAsync(new IdentityRole(changeRole.NewRole));
				}

				var user = await _userManager.FindByIdAsync(changeRole.Id);
				var currentRole = await _userManager.GetRolesAsync(user!);

				var rem = await _userManager.RemoveFromRoleAsync(user!, currentRole[0]);
				var add = await _userManager.AddToRoleAsync(user!, changeRole.NewRole);
				return Ok(true);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Update User's Role (UsersController) : " + ex.HResult + " - " + ex.Message);
				return BadRequest();
			}
		}

		[HttpPost]
		[Route("CheckCredential")]
		public async Task<ActionResult> CheckCredential(LoginViewModel login)
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(login.Email);
				if (user is not null)
				{
					var result = await _userManager.CheckPasswordAsync(user, login.Password);
					if (result)
					{
						user = await _userManager.FindByEmailAsync(login.Email);
						return Ok(user);
					}
				}
				user = new ApplicationUser();
				return Ok(user);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Check Credential (UsersController) : " + ex.HResult + " - " + ex.Message);
				return BadRequest();
			}
		}

		[HttpPost]
		[Route("ChangePassword")]
		public async Task<ActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(changePasswordViewModel.Id);
				var identityResult = await _userManager.ChangePasswordAsync(user!, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);
				if (identityResult.Succeeded)
				{
					return Ok(true);
				}
				return BadRequest(false);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Exception error on Change Password (UsersController) : " + ex.HResult + " - " + ex.Message);
				return BadRequest();
			}
		}
	}
}
