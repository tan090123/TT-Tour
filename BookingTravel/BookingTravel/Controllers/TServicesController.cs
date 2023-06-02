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
    public class TServicesController : ControllerBase
    {
        private readonly TourContext _context;

        public TServicesController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TServicesModel> SearchTServices([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.TServices.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.ServicesName.ToLower().Contains(searchName.ToLower()));
            }

            var services = tourFromDBs.Select(x => new TServicesModel
            {
                TServicesID = x.TServicesID,
                ServicesName = x.ServicesName,
                ServicesPrice = x.ServicesPrice
                
            }).ToList();

            return services;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddTServices([FromBody] TServicesModel newServices)
        {
            var response = new AddTourResultModel();

            var services = new TServices
            {
               ServicesPrice = newServices.ServicesPrice,
               ServicesName = newServices.ServicesName,
            };

            _context.TServices.Add(services);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TServices>> GetServices(int id)
        {
            if (_context.TServices == null)
            {
                return NotFound();
            }
            var services = await _context.TServices.FindAsync(id);

            if (services == null)
            {
                return NotFound();
            }

            return services;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateTServices([FromRoute] int id, [FromBody] TServicesModel updateServices)
        {
            var response = new UpdateTourResultModel();

            var services = _context.TServices.Where(x => x.TServicesID == id).FirstOrDefault();

            if (services == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                services.ServicesName = updateServices.ServicesName;
                services.ServicesPrice = updateServices.ServicesPrice;
               
                _context.Update(services);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteServices([FromRoute] int id)
        {

            var response = new UpdateTourResultModel();

            var services = _context.TServices.Where(x => x.TServicesID == id)
                .FirstOrDefault();

            if (services == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(services);
               await _context.SaveChangesAsync();
            }

            return Ok(services);
        }
    }
}
