﻿using System;
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
    public class ServicesTourController : ControllerBase
    {
        private readonly TourContext _context;

        public ServicesTourController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<ServicesTourModel> SearchTServices([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.ServicesTour.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.ServicesTourName.ToLower().Contains(searchName.ToLower()));
            }

            var services_tour = tourFromDBs.Select(x => new ServicesTourModel
            {
                ServicesTourID = x.ServicesTourID,
                ServicesTourDesc = x.ServicesTourDesc,
                ServicesTourName = x.ServicesTourName,
                TourID = x.TourID,
            }).ToList();

            return services_tour;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddServicesTour([FromBody] ServicesTourModel newServicesTour)
        {
            var response = new AddTourResultModel();

            var services_tour = new ServicesTour
            {
                TourID = newServicesTour.TourID,
                ServicesTourName = newServicesTour.ServicesTourName,
                ServicesTourDesc = newServicesTour.ServicesTourDesc,
               
            };

            _context.ServicesTour.Add(services_tour);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesTour>> GetServicesTour(int id)
        {
            if (_context.ServicesTour == null)
            {
                return NotFound();
            }
            var services_tour = await _context.ServicesTour.FindAsync(id);

            if (services_tour == null)
            {
                return NotFound();
            }

            return services_tour;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateServicesTour([FromRoute] int id, [FromBody] ServicesTourModel updateServicesTour)
        {
            var response = new UpdateTourResultModel();

            var services_tour = _context.ServicesTour.Where(x => x.ServicesTourID == id).FirstOrDefault();

            if (services_tour == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                services_tour.ServicesTourName = updateServicesTour.ServicesTourName;
                services_tour.ServicesTourDesc = updateServicesTour.ServicesTourDesc;
                services_tour.TourID = updateServicesTour.TourID;
               
                _context.Update(services_tour);
                _context.SaveChanges();
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public UpdateTourResultModel DeleteServicesTour([FromRoute] int id)
        {

            var response = new UpdateTourResultModel();

            var services_tour = _context.ServicesTour.Where(x => x.ServicesTourID == id)
                .FirstOrDefault();

            if (services_tour == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(services_tour);
                _context.SaveChanges();
            }

            return response;
        }
    }
}