using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingTravel.Data;
using BookingTravel.Models;

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
                BookingDay  = x.BookingDay,
                BookingID = x.BookingID,
                CurrentPrice = x.CurrentPrice,
                Departure = x.Departure,
                Destination = x.Destination,
                ExtraPrice = x.ExtraPrice,
                Payment = x.Payment,
                Status = x.Status,
                TotalPrice  = x.TotalPrice,
                TourCheckinDays = x.TourCheckinDays,
                TourCheckoutDays = x.TourCheckoutDays,
                TouristID = x.TouristID,
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
                TouristID = newBookings.TouristID,
                UserID = newBookings.UserID,

            };

            _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();

            response.Result = true;

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
                booking.TouristID = updateBookings.TouristID;
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
