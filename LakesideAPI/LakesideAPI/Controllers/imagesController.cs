using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imagesController : ControllerBase
    {
        [HttpGet("type/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }

            var imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return File(imageBytes, "image/png"); // Hoặc loại file hình ảnh tương ứng
        }

    }
}
