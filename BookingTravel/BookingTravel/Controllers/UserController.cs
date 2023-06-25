using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingTravel.Data;
using BookingTravel.Models;
using BookingTravel.Models.Result;
using System.Security.Policy;

namespace BookingTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TourContext _context;

        public UserController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<UserModel> SearchUser([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.Users.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.Fullname.ToLower().Contains(searchName.ToLower()));
            }

            var users = tourFromDBs.Select(x => new UserModel
            {
                UserID = x.UserID,
                Email = x.Email,
                Fullname = x.Fullname,
                PhoneNumber = x.PhoneNumber,
            }).ToList();

            return users;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        [HttpPut("changepassword/{id:int}")]
        public async Task<UpdateTourResultModel> ChangePassword([FromRoute] int id, [FromBody] ChangePasswordModel changePasswordInfo)
        {
            var response = new UpdateTourResultModel();

            var user = _context.Users!.Where(x => x.UserID == id).FirstOrDefault();

            if (user == null)
            {
                response.Result = false;
                response.ErrorMessage = "Người dùng không tồn tại";
                return response;
            }

            bool passwordMatches = BCrypt.Net.BCrypt.Verify(changePasswordInfo.Password, user.Password);

            if (!passwordMatches)
            {
                response.Result = false;
                response.ErrorMessage = "Mật khẩu cũ không chính xác";
                return response;
            }

            // Kiểm tra xem mật khẩu mới và mật khẩu xác nhận có khớp nhau không
            if (changePasswordInfo.NewPassword != changePasswordInfo.ConfirmNewPassword)
            {
                response.Result = false;
                response.ErrorMessage = "Mật khẩu mới và mật khẩu xác nhận không khớp";
                return response;
            }

            // Hash và lưu trữ mật khẩu mới
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(changePasswordInfo.NewPassword, salt);
            user.Password = hash;

            await _context.SaveChangesAsync();

            response.Result = true;
            response.ErrorMessage = "Thay đổi mật khẩu thành công";

            return response;
        }


        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateUser([FromRoute] int id, [FromBody] UserModel updateUser)
        {
            var response = new UpdateTourResultModel();

            var user = _context.Users!.Where(x => x.UserID == id).FirstOrDefault();

            if (user == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                user.PhoneNumber = updateUser.PhoneNumber;
                user.Fullname = updateUser.Fullname;
                user.Email = updateUser.Email;
               
                _context.Update(user);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteUser([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var user = _context.Users.Where(x => x.UserID == id)
                .FirstOrDefault();

            if (user == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(user);
               await _context.SaveChangesAsync();
            }

            return Ok(user);
        }
    }
}
