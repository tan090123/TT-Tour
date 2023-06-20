using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingTravel.Data;
using BookingTravel.Models;
using NuGet.Protocol.Plugins;
using System.Net;

namespace BookingTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisLoginController : ControllerBase
    {
        private readonly TourContext _context;

        public RegisLoginController(TourContext context)
        {
            _context = context;
        }


        [HttpPost("register")]
        public async Task<AddTourResultModel> SignUp(RegisterModel newUser)
        {
            var response = new AddTourResultModel();
            var User_Exists = _context.Users.Where(x => x.Email == newUser.Email).FirstOrDefault();
            if (User_Exists != null)
            {
                response.Result = false;
                response.ErrorMessage = "Email đã được sử dụng";
                return response;
            }
            else
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt();

                // Hash the password with bcrypt
                string hash = BCrypt.Net.BCrypt.HashPassword(newUser.Password, salt);

                var user = new Users
                {
                    Email = newUser.Email,
                    Password = hash,
                    Username = newUser.Username,
                    Fullname = newUser.Fullname,
                    Address = newUser.Address,
                    PhoneNumber = newUser.PhoneNumber
                };

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                response.Result = true;
                response.ErrorMessage = "Đăng ký thành công";

                return response;

            }
        }

        [HttpPost("login")]
        public async Task<AddTourResultModel> Login(LoginModel loginInfo)
        {
            var response = new AddTourResultModel();

            var user = await _context.Users.FirstOrDefaultAsync(x => (x.Email == loginInfo.Value || x.Username == loginInfo.Value));

            if (user == null)
            {
                response.Result = false;
                response.ErrorMessage = "Email hoặc tên người dùng không tồn tại";
                return response;
            }

            bool passwordMatches = BCrypt.Net.BCrypt.Verify(loginInfo.Password, user.Password);

            if (!passwordMatches)
            {
                response.Result = false;
                response.ErrorMessage = "Mật khẩu không chính xác";
                return response;
            }

            response.Result = true;
            response.ErrorMessage = "Đăng nhập thành công";

            return response;
        }

    }
}
