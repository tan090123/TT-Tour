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
    public class TouristType_priceController : ControllerBase
    {
        private readonly TourContext _context;

        public TouristType_priceController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TouristType_priceModel> SearchTouristType([FromQuery] int? TypeID)
        {
            var tourFromDBs = _context.TouristType_price.AsNoTracking();
            if (TypeID != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.TypeID==TypeID);
            }

            var tourist_type = tourFromDBs.Select(x => new TouristType_priceModel
            {
                TypeID = x.TypeID,
                TouristTypeName = x.TouristTypeName,
                tourID=x.tourID,
                touristType_Prices=x.touristType_Prices,
            }).ToList();

            return tourist_type;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddUser([FromBody] TouristType_priceModel newTouristType)
        {
            var response = new AddTourResultModel();

            var tourist_type = new TouristType_price
            {
                TouristTypeName = newTouristType.TouristTypeName,
            };

            _context.TouristType_price.Add(tourist_type);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<TouristType_priceModel>> GetTourSchedule([FromQuery] int? tourID)
        {
            if (_context.TouristType_price == null)
            {
                return NotFound();
            }
            var tour = await _context.Tours.FindAsync(tourID);
            var TouristType_price = _context.TouristType_price.Where(x => x.tourID == tour.TourID).ToList();


            if (TouristType_price == null)
            {
                return NotFound();
            }

            return Ok(TouristType_price);
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateTouristType([FromRoute] int id, [FromBody] TouristType_priceModel updateTouristType)
        {
            var response = new UpdateTourResultModel();

            var tourist_type = _context.TouristType_price.Where(x => x.TypeID == id).FirstOrDefault();

            if (tourist_type == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                tourist_type.TouristTypeName = updateTouristType.TouristTypeName;


                _context.Update(tourist_type);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteTouristType([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var tourist_type = _context.TouristType_price.Where(x => x.TypeID == id)
                .FirstOrDefault();

            if (tourist_type == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(tourist_type);
               await _context.SaveChangesAsync();
            }

            return Ok(tourist_type);
        }
    }
}
