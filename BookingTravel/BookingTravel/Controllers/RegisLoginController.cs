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
using System.Net.Mail;
using BookingTravel.Models.Result;

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
            var User_Exists = _context.Users.Where(x => (x.Email == newUser.Email || x.PhoneNumber == newUser.PhoneNumber)).FirstOrDefault();
            if (User_Exists != null)
            {
                response.Result = false;
                response.ErrorMessage = "Email hoặc số điện thoại đã được sử dụng";
                return response;
            }
            else if(newUser.Password != newUser.ConfirmPassword)
            {
                response.Result = false;
                response.ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp";
                return response;
            } else
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt();

                // Hash the password with bcrypt
                string hash = BCrypt.Net.BCrypt.HashPassword(newUser.Password, salt);

                var user = new Users
                {
                    Email = newUser.Email,
                    Password = hash,
                    Fullname = newUser.Fullname,
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
        public async Task<ForgotResult> Login(LoginModel loginInfo)
        {
            var response = new ForgotResult();

            var user = await _context.Users.FirstOrDefaultAsync(x => (x.Email == loginInfo.Value || x.PhoneNumber == loginInfo.Value));

            if (user == null)
            {
                response.Result = false;
                response.ErrorMessage = "Email hoặc số điện thoại không tồn tại";
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

        [HttpPost("forgot-password")]
        public async Task<ForgotResult> ForgotPassword(ForgotPasswordModel model)
        {
            var response = new ForgotResult();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null)
            {
                response.Result = false;
                response.ErrorMessage = "Email không tồn tại";
                return response;
            }

            // Tạo mật khẩu mới
            string newPassword = GenerateRandomPassword();

            // Hash mật khẩu mới
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword, salt);

            // Cập nhật mật khẩu mới cho người dùng
            user.Password = hashedPassword;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            // Gửi email chứa mật khẩu mới
            SendPasswordResetEmail(user.Email, newPassword);

            response.Result = true;
            response.ErrorMessage = "Mật khẩu mới đã được gửi qua email";

            return response;
        }

        private string GenerateRandomPassword()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var password = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }

        private void SendPasswordResetEmail(string email, string newPassword)
        {
            // Thông tin cấu hình SMTP của bạn
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "contact.doanminhtan@gmail.com";
            string smtpPassword = "jivoznqkjnjhuovo";

            // Địa chỉ email gửi đi và địa chỉ email người nhận
            string senderEmail = "contact.doanminhtan@gmail.com";
            string recipientEmail = email;

            // Tạo đối tượng MailMessage
            MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail);

            // Cấu hình thông tin email
            mailMessage.Subject = "Reset Password";
            mailMessage.Body = "Mật khẩu mới của bạn là: " + newPassword;

            // Tạo đối tượng SmtpClient và gửi email
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }


    }
}
