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
    public class TourGuideController : ControllerBase
    {
        private readonly TourContext _context;

        public TourGuideController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TourGuideModel> SearchTourGuide([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.TourGuide!.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.GuideName.ToLower().Contains(searchName.ToLower()));
            }

            var tour_guide = tourFromDBs.Select(x => new TourGuideModel
            {
                GuideID = x.GuideID,
                GuideName = x.GuideName,
                TourID = x.TourID,
                GuideAddress = x.GuideAddress,
                GuidePhone = x.GuidePhone
            }).ToList();

            return tour_guide;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddTourGuide([FromBody] TourGuideModel newTourGuide)
        {
            var response = new AddTourResultModel();

            var tour_guide = new TourGuide
            {
                GuideName = newTourGuide.GuideName,
                GuidePhone = newTourGuide.GuidePhone,
                GuideAddress = newTourGuide.GuideAddress,
                TourID = newTourGuide.TourID,

            };

            _context.TourGuide.Add(tour_guide);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<TourGuide>> GetTourGuide([FromQuery]int? tourID)
        {
            if (_context.TourGuide == null)
            {
                return NotFound();
            }
            var tour = await _context.Tours.FindAsync(tourID);
            var tour_guide = _context.TourGuide.Where(x => x.TourID == tour.TourID).FirstOrDefault();

            if (tour_guide == null)
            {
                return NotFound();
            }

            return Ok(tour_guide);
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> UpdateTourGuide([FromRoute] int id, [FromBody] TourGuideModel updateTourGuide)
        {
            var response = new UpdateTourResultModel();

            var tour_guide = _context.TourGuide!.Where(x => x.GuideID == id).FirstOrDefault();

            if (tour_guide == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                tour_guide.GuideAddress = updateTourGuide.GuideAddress;
                tour_guide.GuidePhone = updateTourGuide.GuidePhone;
                tour_guide.GuideName = updateTourGuide.GuideName;
                tour_guide.TourID = updateTourGuide.TourID;


                _context.Update(tour_guide);
                await _context.SaveChangesAsync();
            }

            return Ok(tour_guide);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteTourGuide([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var tour_guide = _context.TourGuide.Where(x => x.GuideID == id)
                .FirstOrDefault();

            if (tour_guide == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(tour_guide);
               await _context.SaveChangesAsync();
            }

            return Ok(tour_guide);
        }
    }
}
