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
    public class TouristController : ControllerBase
    {
        private readonly TourContext _context;

        public TouristController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TouristModel> SearchTourist([FromQuery] int searchID)
        {
            var tourFromDBs = _context.Tourist.AsNoTracking();
            if (searchID != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.TourID == searchID);
            }

            var tourist = tourFromDBs.Select(x => new TouristModel
            {
                TouristID = x.TouristID,
                TourID = x.TourID,
                ServicesPrice = x.ServicesPrice,
                TouristDate = x.TouristDate,
                TouristNote = x.TouristNote,
                TouristPrice = x.TouristPrice,
                TouristSex = x.TouristSex,
                TouristType = x.TouristType
                
            }).ToList();

            return tourist;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddTourist([FromBody] TouristModel newToursit)
        {
            var response = new AddTourResultModel();

            var tourist = new Tourist
            {
                ServicesPrice = newToursit.ServicesPrice,
                TouristType = newToursit.TouristType,
                TouristSex = newToursit.TouristSex,
                TouristPrice = newToursit.TouristPrice,
                TouristNote = newToursit.TouristNote,
                TouristDate = newToursit.TouristDate,
                TourID = newToursit.TourID,
                
            };

            _context.Tourist.Add(tourist);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Tourist>> GetTourist(int id)
        {
            if (_context.Tourist == null)
            {
                return NotFound();
            }
            var tourist = await _context.Tourist.FindAsync(id);

            if (tourist == null)
            {
                return NotFound();
            }

            return tourist;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateTourist([FromRoute] int id, [FromBody] TouristModel updateTourist)
        {
            var response = new UpdateTourResultModel();

            var tourist = _context.Tourist.Where(x => x.TouristID == id).FirstOrDefault();

            if (tourist == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                tourist.TouristDate = updateTourist.TouristDate;
                tourist.TouristNote = updateTourist.TouristNote;
                tourist.TouristPrice = updateTourist.TouristPrice;
                tourist.TouristSex = updateTourist.TouristSex;
                tourist.TourID = updateTourist.TourID;
                tourist.ServicesPrice = updateTourist.ServicesPrice;
                tourist.TouristType = updateTourist.TouristType;


                _context.Update(tourist);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public UpdateTourResultModel DeleteTourist([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var tourist = _context.Tourist.Where(x => x.TouristID == id)
                .FirstOrDefault();

            if (tourist == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(tourist);
                _context.SaveChanges();
            }

            return response;
        }
    }
}
