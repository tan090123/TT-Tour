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
    public class TouristServicesController : ControllerBase
    {
        private readonly TourContext _context;

        public TouristServicesController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TouristServicesModel> SearchTouristSV([FromQuery] int? TouristID)
        {
            var tourFromDBs = _context.TouristServices.AsNoTracking();
            if (TouristID != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.TouristID == TouristID);
            }

            var touristSV = tourFromDBs.Select(x => new TouristServicesModel
            {
                ServicesID = x.ServicesID,
                TouristID = x.TouristID,
                TServicesID = x.TServicesID,

            }).ToList();

            return touristSV;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public async Task<ActionResult<AddTourResultModel>> AddTouristSV([FromBody] TouristServicesModel newTouristSV)
        {
            var response = new AddTourResultModel();

            var touristSV = new TouristServices
            {
                TServicesID = newTouristSV.TServicesID,
                TouristID = newTouristSV.TouristID,

            };

            _context.TouristServices.Add(touristSV);

            await _context.SaveChangesAsync();

            response.Result = true;

            return Ok(touristSV);
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
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> UpdateUser([FromRoute] int id, [FromBody] TouristServicesModel updateTouristSV)
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
                await _context.SaveChangesAsync();
            }

            return Ok(touristSV);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteTouristSV([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var touristSV = await _context.TouristServices.FindAsync(id);

            if (touristSV == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(touristSV);
                await _context.SaveChangesAsync();
            }

            return Ok(touristSV);
        }

        [HttpDelete("touristID/{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteTouristSVaa([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var touristSV = await _context.TouristServices.Where(x => x.TouristID == id).ToListAsync();

            if (touristSV == null || touristSV.Count == 0)
            {
                response.Result = false;
                response.ErrorMessage = "Không có bản ghi nào có TouristID là #" + id;
                return BadRequest(response);
            }

            try
            {
                response.Result = true;

                // Xóa từng bản ghi trong danh sách touristSV
                foreach (var touristService in touristSV)
                {
                    _context.TouristServices.Remove(touristService);
                }

                // Lưu thay đổi vào database
                await _context.SaveChangesAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.ErrorMessage = "Đã xảy ra lỗi khi xóa bản ghi có TouristID là #" + id;
                return StatusCode(500, response);
            }
        }
    }
}
