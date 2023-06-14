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
        [HttpPost]
        public async Task<AddTourModel> Upload(IFormFile file)

        {
            var response = new AddTourModel();
            try
            {
                if (file != null && file.Length > 0)
                {
                    // Lấy tên gốc của tệp tin
                    string fileName = file.FileName;

                    // Kết hợp GUID để tạo tên duy nhất trước khi lưu vào thư mục wwwroot
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;

                    // Đường dẫn đầy đủ trong thư mục wwwroot/images
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", fileName);

                    // Copy tệp tin
                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    response.Result = true;
                    response.fileName = uniqueFileName;
                    response.ErrorMessage = "Tải lên thành công";
                    response.ImagePath = "public/images/card/" + uniqueFileName; // Gán đường dẫn tới tệp tin đã tải lên
                }
                else
                {
                    response.Result = false;
                    response.ErrorMessage = "Không có tệp tin được chọn";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
        }
    }
}
