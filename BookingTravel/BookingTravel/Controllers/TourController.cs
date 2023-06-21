using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingTravel.Data;
using BookingTravel.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using BookingTravel.Models.Result;

namespace BookingTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly TourContext _context;
        private readonly UploadController _uploadController;

        public TourController(TourContext context, UploadController uploadController)
        {
            _context = context;
            _uploadController = uploadController;
        }

        /// POST: api/ToursFromDb
        [HttpPost]
        public async Task<ActionResult<AddTourModel>> AddTour([FromForm] TourAddModel newTour)
        {
            var response = new AddTourModel();
            var imageResult = await _uploadController.UploadImage(newTour.TourImage);


            if (imageResult is OkObjectResult result)
            {
                // Lưu trữ tên tệp tin hoặc đường dẫn/tên tệp tin đầy đủ vào cơ sở dữ liệu
                var fileName = result.Value.ToString();
                // Lưu thông tin sản phẩm vào cơ sở dữ liệu
                var tour = new Tours
                {
                    TourName = newTour.TourName,
                    TourCode = newTour.TourCode,
                    TourType = newTour.TourType,
                    TourTotalSit = newTour.TourTotalSit,
                    TourImage = fileName,
                    TourCheckoutDays = newTour.TourCheckoutDays,
                    DiscountTour = newTour.DiscountTour,
                    Departure = newTour.Departure,
                    Description = newTour.Description,
                    Destination = newTour.Destination,
                    Price = newTour.Price,
                    PromotionPrice = newTour.PromotionPrice,
                    TourAvailableSit = newTour.TourAvailableSit,
                    TourCheckinDays = newTour.TourCheckinDays,
                    tour_AvalablePeople = newTour.tour_AvalablePeople,
                    tour_NumberDays = newTour.tour_NumberDays
                };
                _context.Tours.Add(tour);
                _context.SaveChanges();
                response.Result = true;
                return Ok("Product created successfully.");
            }
           return BadRequest("Error uploading image.");
        }


        //GET: api/ToursFromDb
        [HttpGet]
        public List<TourModel> SearchTour([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.Tours.AsNoTracking();


            if (searchName != null)
            {

                tourFromDBs = tourFromDBs.Where(x => x.TourName.ToLower().Contains(searchName.ToLower()));

            }

            var tours = tourFromDBs.Select(x => new TourModel
            {
                TourID = x.TourID,
                TourName = x.TourName,
                Departure = x.Departure,
                Description = x.Description,
                Destination = x.Destination,
                DiscountTour = x.DiscountTour,
                Price = x.Price,
                PromotionPrice = x.PromotionPrice,
                TourAvailableSit = x.TourAvailableSit,
                TourCheckinDays = x.TourCheckinDays,
                TourCheckoutDays = x.TourCheckoutDays,
                TourCode = x.TourCode,
                TourImage = x.TourImage,
                TourTotalSit = x.TourTotalSit,
                TourType = x.TourType,
                tour_AvalablePeople = x.tour_AvalablePeople,
                tour_NumberDays = x.tour_NumberDays
            }).ToList();


            return tours;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Tours>> GetTour(int id)
        {
            if (_context.Tours == null)
            {
                return NotFound();
            }
            var tour = await _context.Tours.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }


        // PUT: api/ToursFromDb/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> UpdateTour([FromRoute] int id, [FromBody] TourModel updateTour)
        {
            var response = new UpdateTourResultModel();

            var tour = _context.Tours.Where(x => x.TourID == id).FirstOrDefault();

            if (tour == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                tour.TourName = updateTour.TourName;
                tour.TourCheckinDays = updateTour.TourCheckinDays;
                tour.TourCheckoutDays = updateTour.TourCheckoutDays;
                tour.TourImage = updateTour.TourImage;
                tour.Departure = updateTour.Departure;
                tour.Description = updateTour.Description;
                tour.Destination = updateTour.Destination;
                tour.DiscountTour = updateTour.DiscountTour;
                tour.TourCode = updateTour.TourCode;
                tour.TourTotalSit = updateTour.TourTotalSit;
                tour.TourType = updateTour.TourType;
                tour.TourAvailableSit = updateTour.TourAvailableSit;
                tour.PromotionPrice = updateTour.PromotionPrice;
                tour.tour_NumberDays = updateTour.tour_NumberDays;
                tour.tour_AvalablePeople=updateTour.tour_AvalablePeople;

                _context.Update(tour);
                await _context.SaveChangesAsync();
               
            }

            return Ok(tour);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteTour([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var tour = await _context.Tours.FindAsync(id) ;

            if (tour == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }

            return Ok(tour);
        }
    }
}
