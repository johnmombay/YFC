using Web.YFC.Common;
using Web.YFC.Models;
using Web.YFC.ViewModels;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class UserServices
	{
		public async Task<List<UserViewModel>> GetUsers()
		{
			List<UserViewModel> userViewModels = new List<UserViewModel>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.UserEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				userViewModels = JsonSerializer.Deserialize<List<UserViewModel>>(result, AppSettings.options)!;
			}
			return userViewModels;
		}

		public async Task<bool> AddUser(RegisterViewModel registerViewModel)
		{
			var data = JsonSerializer.Serialize(registerViewModel).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.UserEndpoint + "/Register/", data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				return true;
			}
			return false;
		}

		public async Task<ApplicationUser> UpdateUser(ApplicationUser applicationUser)
		{
			ApplicationUser applicationUserDb = new ApplicationUser();
			var data = JsonSerializer.Serialize(applicationUser).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.UserEndpoint + "/Update/", data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.UserEndpoint + "/" + applicationUser.Id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				applicationUser = JsonSerializer.Deserialize<ApplicationUser>(result, AppSettings.options)!;
			}
			applicationUser = new ApplicationUser();
			return applicationUser;
		}

		public async Task<ApplicationUser> GetUser(string id)
		{
			ApplicationUser user = new ApplicationUser();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.UserEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				user = JsonSerializer.Deserialize<ApplicationUser>(result, AppSettings.options)!;
			}
			return user;
		}

		public async Task<string> GetRole(string id)
		{
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.UserEndpoint + "/GetRole/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				return result;
			}
			return string.Empty;
		}

		public async Task<bool> UpdateRole(string userId, string role)
		{
			ChangeRoleViewModel changeRole = new ChangeRoleViewModel()
			{
				Id = userId,
				NewRole = role,
			};

			var data = JsonSerializer.Serialize(changeRole).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.UserEndpoint + "/UpdateRole/", data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				return true;
			}
			return false;
		}

		public async Task<ApplicationUser> CheckCredentials(LoginViewModel loginViewModel)
		{
			ApplicationUser applicationUser = new ApplicationUser();

			var data = JsonSerializer.Serialize(loginViewModel).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.UserEndpoint + "/CheckCredential/", data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				applicationUser = JsonSerializer.Deserialize<ApplicationUser>(result, AppSettings.options)!;
			}
			return applicationUser;
		}
	}
}
