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
using System.Net.Mail;
using System.Net;
using System.Globalization;

namespace BookingTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly TourContext _context;

        public BookingsController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<BookingsModel> SearchBookings([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.Bookings.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.BookingName.ToLower().Contains(searchName.ToLower()));
            }

            var booking = tourFromDBs.Select(x => new BookingsModel
            {
                TourID = x.TourID,
                BookingName = x.BookingName,
                BookingDay = x.BookingDay,
                BookingID = x.BookingID,
                CurrentPrice = x.CurrentPrice,
                Departure = x.Departure,
                Destination = x.Destination,
                ExtraPrice = x.ExtraPrice,
                Payment = x.Payment,
                Status = x.Status,
                TotalPrice = x.TotalPrice,
                TourCheckinDays = x.TourCheckinDays,
                TourCheckoutDays = x.TourCheckoutDays,
                InfoContactID = x.InfoContactID,
                UserID = x.UserID,

            }).ToList();

            return booking;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public async Task<ActionResult<AddTourResultModel>> AddBookings([FromBody] BookingsModel newBookings)
        {
            var response = new AddTourResultModel();

            var booking = new Bookings
            {
                TourID = newBookings.TourID,
                BookingName = newBookings.BookingName,
                BookingDay = newBookings.BookingDay,
                CurrentPrice = newBookings.CurrentPrice,
                Departure = newBookings.Departure,
                Destination = newBookings.Destination,
                ExtraPrice = newBookings.ExtraPrice,
                Payment = newBookings.Payment,
                Status = newBookings.Status,
                TotalPrice = newBookings.TotalPrice,
                TourCheckinDays = newBookings.TourCheckinDays,
                TourCheckoutDays = newBookings.TourCheckoutDays,
                InfoContactID = newBookings.InfoContactID,
                UserID = newBookings.UserID,

            };

            _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();

            response.Result = true;

            var contact = _context.InfoContact.FirstOrDefault(x => x.ContactID == booking.InfoContactID);
            if (contact == null || string.IsNullOrEmpty(contact.ContactEmail))
            {
                // Không thể gửi email nếu không có thông tin liên hệ hoặc email không hợp lệ.
                return BadRequest("Không thể gửi email do thiếu thông tin liên hệ hoặc email không hợp lệ.");
            }

            string paymentInVND = booking.TotalPrice.ToString("N0") + " VND";
            // Gửi email chi tiết về tour booking
            string subject = "Thông tin đặt tour #" + booking.TourID;
            string body = "Thông tin tour booking:\n" +
                          "ID: " + booking.BookingID + "\n" +
                          "Tên Tour: " + booking.BookingName + "\n" +
                          "Ngày đặt tour: " + booking.TourCheckinDays + "\n" +
                          "Phương thức thannh toán: " + booking.Payment + "\n" +
                          "Trị giá: " + paymentInVND + "\n" +
                           "-----------------------------------\n" +
                          "Thông tin liên hệ:\n" +
                          "Tên: " + contact.ContactName + "\n" +
                          "Email: " + contact.ContactEmail + "\n" +
                          "Điện thoại: " + contact.ContactPhone + "\n" +
                          "Địa chỉ: " + contact.ContactAddress + "\n";
            // Thêm các thông tin chi tiết khác tùy theo cấu trúc của đối tượng Bookings

            // Thay thế các giá trị sau đây bằng thông tin cấu hình của bạn
            string senderEmail = "minhquanggggg0103@gmail.com";
            string senderPassword = "eqgnnaehtugjznvo";
            string recipientEmail = contact.ContactEmail;

            await SendEmailAsync(subject, body, senderEmail, senderPassword, recipientEmail);

            return Ok(booking);
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookings>> GetBookings(int id)
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }




            return booking;
        }

        private async Task SendEmailAsync(string subject, string body, string senderEmail, string senderPassword, string recipientEmail, string smtpServer = "smtp.gmail.com", int smtpPort = 587)
        {
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);
                await smtpClient.SendMailAsync(mailMessage);
            }
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> UpdateBookings([FromRoute] int id, [FromBody] BookingsModel updateBookings)
        {
            var response = new UpdateTourResultModel();

            var booking = _context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();

            if (booking == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                booking.Status = updateBookings.Status;
                booking.TourCheckinDays = updateBookings.TourCheckinDays;
                booking.TourCheckoutDays = updateBookings.TourCheckoutDays;
                booking.InfoContactID = updateBookings.InfoContactID;
                booking.TourID = updateBookings.TourID;
                booking.CurrentPrice = updateBookings.CurrentPrice;
                booking.Departure = updateBookings.Departure;
                booking.Destination = updateBookings.Destination;
                booking.ExtraPrice = updateBookings.ExtraPrice;
                booking.Payment = updateBookings.Payment;
                booking.UserID = updateBookings.UserID;
                booking.TotalPrice = updateBookings.TotalPrice;
                booking.BookingDay = updateBookings.BookingDay;
                booking.BookingName = updateBookings.BookingName;


                _context.Update(booking);
                await _context.SaveChangesAsync();
            }

            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteBookings([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(booking);
                await _context.SaveChangesAsync();
            }

            return Ok(booking);
        }
    }
}
