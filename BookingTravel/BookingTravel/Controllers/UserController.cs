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
    public class UserController : ControllerBase
    {
        private readonly TourContext _context;

        public UserController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<UserModel> SearchUser([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.Users!.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.Fullname.ToLower().Contains(searchName.ToLower()));
            }

            var users = tourFromDBs.Select(x => new UserModel
            {
                UserID = x.UserID,
                Address = x.Address,
                Email = x.Email,
                Fullname = x.Fullname,
                PhoneNumber = x.PhoneNumber,
                Username = x.Username
            }).ToList();

            return users;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public async Task<ActionResult<AddTourResultModel>> AddUser([FromBody] AddUserModel newUser)
        {
            var response = new AddTourResultModel();

            var user = new Users
            {
                UserID = newUser.UserID,
                Address = newUser.Address,
                Email = newUser.Email,
                Username= newUser.Username,
                PhoneNumber = newUser.PhoneNumber,
                Fullname = newUser.Fullname,
                Password = newUser.Password
                
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            response.Result = true;

            return Ok(user);
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateUser([FromRoute] int id, [FromBody] UserModel updateUser)
        {
            var response = new UpdateTourResultModel();

            var user = _context.Users!.Where(x => x.UserID == id).FirstOrDefault();

            if (user == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                user.Username = updateUser.Username;
                user.PhoneNumber = updateUser.PhoneNumber;
                user.Fullname = updateUser.Fullname;
                user.Email = updateUser.Email;
                user.Address = updateUser.Address;
               
                _context.Update(user);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteUser([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var user = _context.Users.Where(x => x.UserID == id)
                .FirstOrDefault();

            if (user == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(user);
               await _context.SaveChangesAsync();
            }

            return Ok(user);
        }
    }
}
