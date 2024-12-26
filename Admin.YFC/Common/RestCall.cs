using System.Net.Http.Headers;
using System.Text;

namespace Admin.YFC.Common
{
	public class RestCall
	{
		public static async Task<string> Get(string url)
		{
			using (var client = new HttpClient())
			{

				client.DefaultRequestHeaders.Add(AppSettings.ApiKey, AppSettings.ApiSecret);
				using (var response = await client.GetAsync(url))
				{
					if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
					{
						return string.Empty;
					}
					return await response.Content.ReadAsStringAsync();
				}
			}
		}

		public static async Task<string> Post(string url, string data)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add(AppSettings.ApiKey, AppSettings.ApiSecret);
				var content = new StringContent(data, Encoding.UTF8, "text/json");
				using (var response = await client.PostAsync(url, content))
				{
					return await response.Content.ReadAsStringAsync();
				}
			}
		}

		public static async Task<string> Put(string url, string data)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add(AppSettings.ApiKey, AppSettings.ApiSecret);
				var content = new StringContent(data, Encoding.UTF8, "text/json");
				using (var response = await client.PutAsync(url, content))
				{
					return await response.Content.ReadAsStringAsync();
				}
			}
		}

		public static async Task<string> Remove(string url)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add(AppSettings.ApiKey, AppSettings.ApiSecret);
				using (var response = await client.DeleteAsync(url))
				{
					return await response.Content.ReadAsStringAsync();
				}
			}
		}

		public static async Task<bool> Upload(IFormFile file, string folder, string fileName)
		{
			try
			{
				if (file != null && file.Length > 0)
				{
					using var client = new HttpClient();
					client.BaseAddress = new Uri(AppSettings.ApiUri);
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					client.DefaultRequestHeaders.Add(AppSettings.ApiKey, AppSettings.ApiSecret);

					byte[] data;
					using (var br = new BinaryReader(file.OpenReadStream()))
						data = br.ReadBytes((int)file.OpenReadStream().Length);

					ByteArrayContent bytes = new ByteArrayContent(data);

					var content = new MultipartFormDataContent();
					content.Add(bytes, "file", file.FileName);
					content.Add(new StringContent(folder), "folder");
					content.Add(new StringContent(fileName), "fileName");

					var fileExtension = Path.GetExtension(file.FileName);
					if (fileExtension.ToUpper() == ".JPG" || fileExtension.ToUpper() == ".PNG")
					{
						var response = await client.PostAsync("api/FileUpload", content);
						if (!response.IsSuccessStatusCode)
						{
							return false;
						}
						else
						{
							return true;
						}
					}
					return false;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static async Task<bool> DeleteFile(string uRL, string folder, string id, string fileName)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add(AppSettings.ApiKey, AppSettings.ApiSecret);

				var url = uRL + $"/{folder}/{id}/{fileName}";
				using (var response = await client.DeleteAsync(url))
				{
					if (!response.IsSuccessStatusCode)
					{
						return false;
					}
					else
					{
						return true;
					}
				}
			}
		}
	}
}
