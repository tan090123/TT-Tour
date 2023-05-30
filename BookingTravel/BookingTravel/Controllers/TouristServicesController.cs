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
    public class TouristServicesController : ControllerBase
    {
        private readonly TourContext _context;

        public TouristServicesController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TouristServicesModel> SearchTouristSV([FromQuery] int searchID)
        {
            var tourFromDBs = _context.TouristServices.AsNoTracking();
            if (searchID != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.TouristID == searchID);
            }

            var touristSV = tourFromDBs.Select(x => new TouristServicesModel
            {
                TouristID = x.TouristID,
                ServicesID = x.ServicesID,
                TServicesID = x.ServicesID,
               
            }).ToList();

            return touristSV;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddTouristSV([FromBody] TouristServicesModel newTouristSV)
        {
            var response = new AddTourResultModel();

            var touristSV = new TouristServices
            {
                TServicesID = newTouristSV.ServicesID,
                TouristID = newTouristSV.ServicesID,
                
            };

            _context.TouristServices.Add(touristSV);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TouristServices>> GetTouristSV(int id)
        {
            if (_context.TouristServices == null)
            {
                return NotFound();
            }
            var touristSV = await _context.TouristServices.FindAsync(id);

            if (touristSV == null)
            {
                return NotFound();
            }

            return touristSV;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateUser([FromRoute] int id, [FromBody] TouristServicesModel updateTouristSV)
        {
            var response = new UpdateTourResultModel();

            var touristSV = _context.TouristServices!.Where(x => x.ServicesID == id).FirstOrDefault();

            if (touristSV == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                touristSV.TouristID = updateTouristSV.TouristID;
                touristSV.TServicesID = updateTouristSV.TServicesID;

                _context.Update(touristSV);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public UpdateTourResultModel DeleteTouristSV([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var touristSV = _context.TouristServices.Where(x => x.ServicesID == id)
                .FirstOrDefault();

            if (touristSV == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(touristSV);
                _context.SaveChanges();
            }

            return response;
        }
    }
}
