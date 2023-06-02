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
    public class TourImagesController : ControllerBase
    {
        private readonly TourContext _context;

        public TourImagesController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TourImagesModel> SearchUser([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.TourImages.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.Images.ToLower().Contains(searchName.ToLower()));
            }

            var tourimages = tourFromDBs.Select(x => new TourImagesModel
            {
                ImageID = x.ImageID,
                Images = x.Images,
                TourID = x.TourID,
            }).ToList();

            return tourimages;
        }
        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddImages([FromBody] TourImagesModel newImages)
        {
            var response = new AddTourResultModel();

            var tourimages = new TourImages
            {
                Images = newImages.Images,
                TourID=newImages.TourID,
            };

            _context.TourImages.Add(tourimages);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TourImages>> GetImages(int id)
        {
            if (_context.TourImages == null)
            {
                return NotFound();
            }
            var tourimages = await _context.TourImages.FindAsync(id);

            if (tourimages == null)
            {
                return NotFound();
            }

            return tourimages;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateImages([FromRoute] int id, [FromBody] TourImagesModel updateImages)
        {
            var response = new UpdateTourResultModel();

            var tourimages = _context.TourImages.Where(x => x.ImageID == id).FirstOrDefault();

            if (tourimages == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                tourimages.Images = updateImages.Images;
                tourimages.TourID=updateImages.TourID;

                _context.Update(tourimages);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteImages([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var tourimages = _context.TourImages.Where(x => x.ImageID == id)
                .FirstOrDefault();

            if (tourimages == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(tourimages);
                await _context.SaveChangesAsync();
            }

            return Ok(tourimages);
        }
    }
}
