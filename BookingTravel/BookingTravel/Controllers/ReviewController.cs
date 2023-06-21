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
    public class ReviewController : ControllerBase
    {
        private readonly TourContext _context;

        public ReviewController(TourContext context)
        {
            _context = context;
        }

        // GET: api/ToursFromDb
        [HttpGet]
        public List<ReviewModel> SearchReview([FromQuery] string? searchName)
        {
            var tourFromDBs = _context.Reviews.AsNoTracking();
            if (searchName != null)
            {
                tourFromDBs = tourFromDBs.Where(x => x.Comment.ToLower().Contains(searchName.ToLower()));
            }

            var review = tourFromDBs.Select(x => new ReviewModel
            {
                ReviewsID = x.ReviewsID,
                UserID = x.UserID,
                Comment = x.Comment,
                Rating = x.Rating,
                ReviewDay = x.ReviewDay,
                TourID = x.TourID,
                
            }).ToList();

            return review;
        }

        //// POST: api/ToursFromDb
        [HttpPost]
        public AddTourResultModel AddReview([FromBody] ReviewModel newReview)
        {
            var response = new AddTourResultModel();

            var review = new Review
            {
               TourID = newReview.TourID,
               ReviewDay = newReview.ReviewDay,
               Rating = newReview.Rating,
               Comment = newReview.Comment,
               UserID=newReview.UserID,
               ReviewsID = newReview.ReviewsID,
               
            };

            _context.Reviews!.Add(review);

            _context.SaveChanges();

            response.Result = true;

            return response;
        }

        // GET: api/ToursFromDb/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            if (_context.Reviews == null)
            {
                return NotFound();
            }
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/ToursFromDb/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<UpdateTourResultModel>> UpdateReview([FromRoute] int id, [FromBody] ReviewModel updateReview)
        {
            var response = new UpdateTourResultModel();

            var review = _context.Reviews.Where(x => x.ReviewsID == id).FirstOrDefault();

            if (review == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                review.TourID = updateReview.TourID;
                review.Comment = updateReview.Comment;
                review.Rating = updateReview.Rating;
                review.UserID = updateReview.UserID;
                review.ReviewDay = updateReview.ReviewDay;
               
                _context.Update(review);
               await _context.SaveChangesAsync();
            }

            return Ok(review);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateTourResultModel>> DeleteReview([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var review = _context.Reviews.Where(x => x.ReviewsID == id)
                .FirstOrDefault();

            if (review == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                _context.Remove(review);
               await _context.SaveChangesAsync();
            }

            return Ok(review);
        }
    }
}
