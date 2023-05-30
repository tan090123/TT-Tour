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
    public class RoleController : ControllerBase
    {
        private readonly TourContext _context;

        public RoleController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<RoleModel> SearchRole([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.Roles.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.RoleName.ToLower().Contains(searchName.ToLower()));
            }

            var roles = tourFromDBs.Select(x => new RoleModel
            {
                RoleID = x.RoleID,
                RoleName = x.RoleName,
                RoleCode = x.RoleCode
            }).ToList();

            return roles;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddRole([FromBody] RoleModel newRole)
        {
            var response = new AddTourResultModel();

            var role = new Roles
            {
               RoleName = newRole.RoleName,
               RoleCode = newRole.RoleCode
                
            };

            _context.Roles!.Add(role);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRole(int id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateRole([FromRoute] int id, [FromBody] RoleModel updateRole)
        {
            var response = new UpdateTourResultModel();

            var role = _context.Roles!.Where(x => x.RoleID == id).FirstOrDefault();

            if (role == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                role.RoleName = updateRole.RoleName;
                role.RoleCode = updateRole.RoleCode;
               
                _context.Update(role);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public UpdateTourResultModel DeleteRole([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var role = _context.Roles.Where(x => x.RoleID == id)
                .FirstOrDefault();

            if (role == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(role);
                _context.SaveChanges();
            }

            return response;
        }
    }
}
