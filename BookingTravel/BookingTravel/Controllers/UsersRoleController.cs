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
    public class UsersRoleController : ControllerBase
    {
        private readonly TourContext _context;

        public UsersRoleController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<UsersRoleModel> SearchUsersRole([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.UsersRole!.AsNoTracking();
            //if (searchName != null)
            //{
            //    tourFromDBs = tourFromDBs.Where(x => x.UserRoleID.ToLower().Contains(searchName.ToLower()));
            //}

            var usersrole = tourFromDBs.Select(x => new UsersRoleModel
            {
                UserRoleID = x.UserRoleID,
                UserID = x.UserID,
                RoleID = x.RoleID,
                
            }).ToList();

            return usersrole;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddUsersRole([FromBody] UsersRoleModel newUserRole)
        {
            var response = new AddTourResultModel();

            var usersRole = new UsersRole
            {
               UserID = newUserRole.UserID,
               RoleID = newUserRole.RoleID,
            };

            _context.UsersRole!.Add(usersRole);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersRole>> GetUsersRole(int id)
        {
            if (_context.UsersRole == null)
            {
                return NotFound();
            }
            var usersrole = await _context.UsersRole.FindAsync(id);

            if (usersrole == null)
            {
                return NotFound();
            }

            return usersrole;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateUsersRole([FromRoute] int id, [FromBody] UsersRoleModel updateUsersRole)
        {
            var response = new UpdateTourResultModel();

            var usersrole = _context.UsersRole.Where(x => x.UserRoleID == id).FirstOrDefault();

            if (usersrole == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                usersrole.UserID = updateUsersRole.UserID;
                usersrole.RoleID = updateUsersRole.RoleID;
   
               
                _context.Update(usersrole);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteUsersRole([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var usersrole = _context.UsersRole.Where(x => x.UserRoleID == id)
                .FirstOrDefault();

            if (usersrole == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(usersrole);
               await _context.SaveChangesAsync();
            }

            return Ok(usersrole);
        }
    }
}
