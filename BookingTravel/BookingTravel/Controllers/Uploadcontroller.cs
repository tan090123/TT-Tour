using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingTravel.Data;
using BookingTravel.Models;
using Azure;


namespace BookingTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public UploadController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile TourImage)

        {
            if (TourImage == null || TourImage.Length == 0)
            {
                return BadRequest("Chưa upload ảnh.");
            }

            //var fileName = Path.GetFileName(TourImage.FileName);
            var fileName = Guid.NewGuid().ToString().Substring(0, 8) + Path.GetExtension(TourImage.FileName);
            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images" , fileName);

            // Kiểm tra nếu tệp tin đã tồn tại
            if (System.IO.File.Exists(filePath))
            {
                // Xử lý trường hợp trùng tên tệp tin ở đây
                return BadRequest("tên ảnh đã bị trùng");
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await TourImage.CopyToAsync(stream);
            }

            return Ok(fileName);
        }

        [HttpGet("{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(fileStream, "imagesz/jpeg");
        }
    }
}
