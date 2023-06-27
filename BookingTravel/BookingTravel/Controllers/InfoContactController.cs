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
    public class InfoContactController : ControllerBase
    {
        private readonly TourContext _context;

        public InfoContactController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<InfoContactModel> SearchContact([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.InfoContact.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.ContactName.ToLower().Contains(searchName.ToLower()));
            }

            var contact = tourFromDBs.Select(x => new InfoContactModel
            {
                ContactID = x.ContactID,
                ContactName = x.ContactName,
                ContactEmail = x.ContactEmail,
                ContactPhone = x.ContactPhone,
                ContactAddress = x.ContactAddress,
                ContactNote = x.ContactNote,
                TourID = x.TourID,
                
            }).ToList();

            return contact;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public async Task<ActionResult<AddTourResultModel>> AddContact([FromBody] InfoContactModel newContact)
        {
            var response = new AddTourResultModel();

            var contact = new InfoContact
            {
               TourID = newContact.TourID,
               ContactAddress = newContact.ContactAddress,
               ContactName = newContact.ContactName,
               ContactEmail = newContact.ContactEmail,
               ContactPhone = newContact.ContactPhone,
                ContactNote = newContact.ContactNote,

            };

            _context.InfoContact.Add(contact);

            await _context.SaveChangesAsync();

            response.Result = true;

            return Ok(contact);
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoContact>> GetContact(int id)
        {
            if (_context.InfoContact == null)
            {
                return NotFound();
            }
            var contact = await _context.InfoContact.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateContact([FromRoute] int id, [FromBody] InfoContactModel updateContact)
        {
            var response = new UpdateTourResultModel();

            var contact = _context.InfoContact.Where(x => x.ContactID == id).FirstOrDefault();

            if (contact == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                contact.TourID = updateContact.TourID;
                contact.ContactEmail = updateContact.ContactEmail;
                contact.ContactPhone = updateContact.ContactPhone;
                contact.ContactName = updateContact.ContactName;
                contact.ContactAddress = updateContact.ContactAddress;
                contact.ContactNote = updateContact.ContactNote;
               
                _context.Update(contact);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public UpdateTourResultModel DeleteContact([FromRoute] int id)
        {

            var response = new UpdateTourResultModel();

            var contact = _context.InfoContact.Where(x => x.ContactID == id)
                .FirstOrDefault();

            if (contact == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(contact);
                _context.SaveChanges();
            }

            return response;
        }
    }
}
