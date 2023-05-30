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
    public class TouristTypeController : ControllerBase
    {
        private readonly TourContext _context;

        public TouristTypeController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TouristTypeModel> SearchTouristType([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.TouristType!.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.TypeName.ToLower().Contains(searchName.ToLower()));
            }

            var tourist_type = tourFromDBs.Select(x => new TouristTypeModel
            {
               TypeID = x.TypeID,
               TypeName = x.TypeName,
            }).ToList();

            return tourist_type;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddUser([FromBody] TouristTypeModel newTouristType)
        {
            var response = new AddTourResultModel();

            var tourist_type = new TouristType
            {
                TypeName = newTouristType.TypeName,
            };

            _context.TouristType!.Add(tourist_type);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TouristType>> GetTouristType(int id)
        {
            if (_context.TouristType == null)
            {
                return NotFound();
            }
            var tourist_type = await _context.TouristType.FindAsync(id);

            if (tourist_type == null)
            {
                return NotFound();
            }

            return tourist_type;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateTouristType([FromRoute] int id, [FromBody] TouristTypeModel updateTouristType)
        {
            var response = new UpdateTourResultModel();

            var tourist_type = _context.TouristType!.Where(x => x.TypeID == id).FirstOrDefault();

            if (tourist_type == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                tourist_type.TypeName = updateTouristType.TypeName;


                _context.Update(tourist_type);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public UpdateTourResultModel DeleteTouristType([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var tourist_type = _context.TouristType.Where(x => x.TypeID == id)
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
                _context.SaveChanges();
            }

            return response;
        }
    }
}
