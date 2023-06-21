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
    public class TourScheduleController : ControllerBase
    {
        private readonly TourContext _context;

        public TourScheduleController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<TourScheduleModel> SearchSchedule([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.TourSchedule.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.ScheduleName.ToLower().Contains(searchName.ToLower()));
            }

            var schedule = tourFromDBs.Select(x => new TourScheduleModel
            {
                ScheduleID = x.ScheduleID,
                ScheduleDesc = x.ScheduleDesc,
                ScheduleName = x.ScheduleName,
                ScheduleNote = x.ScheduleNote,
                TourID = x.TourID,
            }).ToList();

            return schedule;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public async Task<ActionResult<AddTourResultModel>> AddSchedule([FromBody] TourScheduleModel newSchedule)
        {
            var response = new AddTourResultModel();

            var schedule = new TourSchedule
            {
                ScheduleDesc = newSchedule.ScheduleDesc,
                ScheduleName = newSchedule.ScheduleName,
                ScheduleNote = newSchedule.ScheduleNote,
                TourID = newSchedule.TourID,
                
            };

            _context.TourSchedule.Add(schedule);

            await _context.SaveChangesAsync();

            response.Result = true;

            return Ok(schedule);
        }

        // GET: api/ToursFromDb/id
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<TourScheduleModel>> GetTourSchedule([FromQuery] int? tourID)
        {
            if (_context.TourSchedule == null)
            {
                return NotFound();
            }
            var tour = await _context.Tours.FindAsync(tourID);
            var tour_schedule = _context.TourSchedule.Where(x => x.TourID == tour.TourID).ToList();


            if (tour_schedule == null)
            {
                return NotFound();
            }

            return Ok(tour_schedule);
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateSchedule([FromRoute] int id, [FromBody] TourScheduleModel updateSchedule)
        {
            var response = new UpdateTourResultModel();

            var schedule = _context.TourSchedule.Where(x => x.ScheduleID == id).FirstOrDefault();

            if (schedule == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                schedule.ScheduleNote = updateSchedule.ScheduleNote;
                schedule.TourID = updateSchedule.TourID;
                schedule.ScheduleName = updateSchedule.ScheduleName;
                schedule.ScheduleDesc = updateSchedule.ScheduleDesc;

               
                _context.Update(schedule);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteSchedule([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var schedule = _context.TourSchedule.Where(x => x.ScheduleID == id)
                .FirstOrDefault();

            if (schedule == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(schedule);
                await _context.SaveChangesAsync();
            }

            return Ok(schedule);
        }
    }
}
