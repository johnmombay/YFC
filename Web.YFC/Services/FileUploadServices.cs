using Web.YFC.Common;

namespace Web.YFC.Services
{
	public class FileUploadServices
	{
		public async Task<bool> Upload(IFormFile file, string folder, string fileName)
		{
			var result = await RestCall.Upload(file, folder, fileName);
			return result;
		}

		public async Task<bool> Remove(string folder, string id, string fileName)
		{
			var result = await RestCall.DeleteFile(AppSettings.ApiUri + EndPoints.FileUploadEndpoint, folder, id, fileName);
			return result;
		}
	}
}
