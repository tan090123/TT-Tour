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
        public List<TouristModel> SearchTourist([FromQuery] int? searchID)
        {
            var tourFromDBs = _context.Tourist.AsNoTracking();
            if (searchID != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.TouristID == searchID);
            }

            var tourist = tourFromDBs.Select(x => new TouristModel
            {
                TouristID = x.TouristID,
                ServicesPrice = x.ServicesPrice,
                TouristName = x.TouristName,

                TouristDate = x.TouristDate,
 
                TouristPrice = x.TouristPrice,
                TouristSex = x.TouristSex,
                TouristType = x.TouristType
                
            }).ToList();

            return tourist;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public async Task<ActionResult<AddTourResultModel>> AddTourist([FromBody] TouristModel newToursit)
        {
            var response = new AddTourResultModel();

            var tourist = new Tourist
            {
                ServicesPrice = newToursit.ServicesPrice,
                TouristType = newToursit.TouristType,
                TouristName= newToursit.TouristName,
                TouristSex = newToursit.TouristSex,
                TouristPrice = newToursit.TouristPrice,
                TouristDate = newToursit.TouristDate,
                
            };

            _context.Tourist.Add(tourist);

            await _context.SaveChangesAsync();

            response.Result = true;

            return Ok(tourist);
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
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> UpdateTourist([FromRoute] int id, [FromBody] TouristModel updateTourist)
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
                tourist.TouristName = updateTourist.TouristName;
                tourist.TouristPrice = updateTourist.TouristPrice;
                tourist.TouristSex = updateTourist.TouristSex;
                tourist.ServicesPrice = updateTourist.ServicesPrice;
                tourist.TouristType = updateTourist.TouristType;


                _context.Update(tourist);
                await _context.SaveChangesAsync();
            }

            return Ok(tourist);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteTourist([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var tourist = _context.Tourist.Find(id);

            if (tourist == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(tourist);
                await _context.SaveChangesAsync();
            }

            return Ok(tourist);
        }
    }
}
