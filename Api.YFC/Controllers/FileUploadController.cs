using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.YFC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileUploadController : ControllerBase
	{
		[HttpPost]
		public ActionResult UploadImage(IFormFile file, [FromForm] string folder, [FromForm] string fileName)
		{
			try
			{
				// Create directory if it doesn't exist
				var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", folder);
				if (!Directory.Exists(folderPath))
				{
					Directory.CreateDirectory(folderPath);
				}

				// Save image to specified folder
				var filePath = Path.Combine(folderPath, fileName);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					file.CopyTo(stream);
				}

				return Ok("Image uploaded successfully.");
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpDelete("{folder}/{id}/{fileName}")]
		public ActionResult DeleteImage(string folder, string id, string fileName)
		{
			try
			{
				// Check if the file exists
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", folder, id, fileName);
				if (!System.IO.File.Exists(filePath))
				{
					return NotFound("The specified file does not exist.");
				}

				// Delete the file
				System.IO.File.Delete(filePath);

				return Ok("The file has been deleted successfully.");
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
