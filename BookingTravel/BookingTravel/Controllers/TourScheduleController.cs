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
        public AddTourResultModel AddSchedule([FromBody] TourScheduleModel newSchedule)
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

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TourSchedule>> GetSchedule(int id)
        {
            if (_context.TourSchedule == null)
            {
                return NotFound();
            }
            var schedule = await _context.TourSchedule.FindAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return schedule;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateSchedule([FromRoute] int id, [FromBody] UserModel updateSchedule)
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

                schedule.ScheduleNote = schedule.ScheduleNote;
                schedule.TourID = schedule.TourID;
                schedule.ScheduleName = schedule.ScheduleName;
                schedule.ScheduleDesc = schedule.ScheduleDesc;

               
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
