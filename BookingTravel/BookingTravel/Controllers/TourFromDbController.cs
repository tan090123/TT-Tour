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
    public class TourFromDbController : ControllerBase
    {
        private readonly TourContext _context;

        public TourFromDbController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TourModel> SearchTour([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.Tours!.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.Name.ToLower().Contains(searchName.ToLower()));
            }

            var tours = tourFromDBs.Select(x => new TourModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Departure = x.Departure,
                Destination = x.Destination,
                Description = x.Description!,
                Price = x.Price,
                Start_date = x.Start_date,
                End_date = x.End_date,
                DateTime = x.DateTime,
            }).ToList();

            return tours;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddTour([FromBody] TourModel newTour)
        {
            var response = new AddTourResultModel();

            var tour = new Tour
            {
                Name = newTour.Name,
                ImageUrl = newTour.ImageUrl,
                Departure = newTour.Departure,
                Destination = newTour.Destination,
                Description = newTour.Description!,
                Price = newTour.Price,
                Start_date = newTour.Start_date,
                End_date = newTour.End_date,
                DateTime = newTour.DateTime,
            };

            _context.Tours!.Add(tour);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(int id)
        {
            if (_context.Tours == null)
            {
                return NotFound();
            }
            var tour = await _context.Tours.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateTour([FromRoute] int id, [FromBody] TourModel updateTour)
        {
            var response = new UpdateTourResultModel();

            var tour = _context.Tours!.Where(x => x.Id == id).FirstOrDefault();

            if (tour == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                tour.Name = updateTour.Name;
                tour.ImageUrl = updateTour.ImageUrl;
                tour.Description = updateTour.Description;
                tour.Departure = updateTour.Departure;
                tour.Destination = updateTour.Destination;
                tour.Price = updateTour.Price;
                tour.Start_date = updateTour.Start_date;
                tour.End_date = updateTour.End_date;
                tour.DateTime = updateTour.DateTime;

                _context.Update(tour);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public UpdateTourResultModel DeleteTour([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var tour = _context.Tours!.Where(x => x.Id == id)
                .FirstOrDefault();

            if (tour == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(tour);
                _context.SaveChanges();
            }

            return response;
        }
    }
}
