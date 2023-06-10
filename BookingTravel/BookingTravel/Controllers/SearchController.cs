using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingTravel.Data;
using BookingTravel.Models;
using System.Globalization;

namespace BookingTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SearchController : ControllerBase
    {
        private readonly TourContext _context;

        public SearchController(TourContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tours>>> Search(string? departure, string? destination, DateTime? datetime, int? numberDay)
        {
            var tourFromDBs = _context.Tours.AsNoTracking();

            if (departure != null )
            {
                tourFromDBs = tourFromDBs.Where(x => x.Departure.ToLower().Contains(departure.ToLower()));
               
            }
            if (destination != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.Destination.ToLower().Contains(destination.ToLower()));

            }

            var search = tourFromDBs.Select(x => new TourModel
            {
                TourID = x.TourID,
                TourName = x.TourName,
                Departure = x.Departure,
                Description = x.Description,
                Destination = x.Destination,
                DiscountTour = x.DiscountTour,
                Price = x.Price,
                PromotionPrice = x.PromotionPrice,
                TourAvailableSit = x.TourAvailableSit,
                TourCheckinDays = x.TourCheckinDays,
                TourCheckoutDays = x.TourCheckoutDays,
                TourCode = x.TourCode,
                TourImage = x.TourImage,
                TourTotalSit = x.TourTotalSit,
                TourType = x.TourType,
            }).ToList();

            return Ok(search);

        }
    }
}
