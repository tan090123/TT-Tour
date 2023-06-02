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
    public class TourTypeController : ControllerBase
    {
        private readonly TourContext _context;

        public TourTypeController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TourTypeModel> SearchUser([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.TourType!.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.TypeName.ToLower().Contains(searchName.ToLower()));
            }

            var tour_type = tourFromDBs.Select(x => new TourTypeModel
            {
                TypeID = x.TypeID,
                TypeName = x.TypeName,
            }).ToList();

            return tour_type;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddTourType([FromBody] TourTypeModel newTourType)
        {
            var response = new AddTourResultModel();

            var tour_type = new TourType
            {
               TypeName = newTourType.TypeName,
                
            };

            _context.TourType!.Add(tour_type);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TourType>> GetTourType(int id)
        {
            if (_context.TourType == null)
            {
                return NotFound();
            }
            var tour_type = await _context.TourType.FindAsync(id);

            if (tour_type == null)
            {
                return NotFound();
            }

            return tour_type;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateTourType([FromRoute] int id, [FromBody] TourTypeModel updateTourType)
        {
            var response = new UpdateTourResultModel();

            var tour_type = _context.TourType!.Where(x => x.TypeID == id).FirstOrDefault();

            if (tour_type == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                tour_type.TypeName = updateTourType.TypeName;

                _context.Update(tour_type);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteUser([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var tour_type = _context.TourType.Where(x => x.TypeID == id)
                .FirstOrDefault();

            if (tour_type == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(tour_type);
               await _context.SaveChangesAsync();
            }

            return Ok(tour_type);
        }
    }
}
