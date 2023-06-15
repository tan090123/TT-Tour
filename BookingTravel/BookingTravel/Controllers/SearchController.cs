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
using NuGet.Versioning;

namespace BookingTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SearchController : ControllerBase
    {
        private readonly TourContext _context;

        public SearchController(TourContext context)
        {
            _context = context;
        }

        [HttpGet("{departure}/{destination}/{datetime}/{numberDay}/{tourtype}")]
     
        public async Task<ActionResult<IEnumerable<Tours>>> Search(string? departure, string? destination, DateTime? datetime, string? numberDay, int tourtype, [FromQuery] string? people)
        {
            var tourFromDBs = _context.Tours.AsNoTracking();
            DateTime current=DateTime.Now;

            if (departure == "All" && destination == "All" && numberDay == "All" && datetime == current && tourtype==0)
            {
                return Ok(await _context.Tours.ToListAsync());
            }
            else
            {
                if (departure != "All")
                {
                    tourFromDBs = tourFromDBs.Where(x => x.Departure.ToLower().Contains(departure.ToLower()));

                }
                if (datetime != null)
                {
                    tourFromDBs = tourFromDBs.Where(x => x.TourCheckinDays >= datetime);

                }
                if (destination != "All")
                {
                    tourFromDBs = tourFromDBs.Where(x => x.Destination.ToLower().Contains(destination.ToLower()));

                }
                if (numberDay != "All")
                {
                    int Fsearch;
                    int Lsearch;
                    int index = numberDay.IndexOf("-");
                    string firstPart = numberDay.Substring(0, index);
                    string secondPart = numberDay.Substring(index + 1);
                    int.TryParse(firstPart, out Fsearch);
                    int.TryParse(secondPart, out Lsearch);
                    
                        tourFromDBs = tourFromDBs.Where(x => x.tour_NumberDays >= Fsearch && x.tour_NumberDays <= Lsearch);
                    
                }
                if (tourtype != 0)
                {
                    tourFromDBs = tourFromDBs.Where(x => x.TourType.Equals(tourtype));

                }
                if (people != null)
                {
                    if (people == "3-5")
                    {
                        int Fsearch;
                        int Lsearch;
                        int index = people.IndexOf("-");
                        string firstPart = people.Substring(0, index);
                        string secondPart = people.Substring(index + 1);
                        int.TryParse(firstPart, out Fsearch);
                        int.TryParse(secondPart, out Lsearch);
                        tourFromDBs = tourFromDBs.Where(x => x.tour_AvalablePeople >= Fsearch && x.tour_AvalablePeople <= Lsearch);
                    }
                    else
                    {
                        int check;
                        int.TryParse(people, out check);

                        switch (check)
                        {
                            case 1:

                                tourFromDBs = tourFromDBs.Where(x => x.tour_AvalablePeople.Equals(check)); 
                                break;

                            case 2:
                                
                                tourFromDBs = tourFromDBs.Where(x => x.tour_AvalablePeople.Equals(check));
                                break;
                            
                            case 5:
                
                                tourFromDBs = tourFromDBs.Where(x => x.tour_AvalablePeople > check);
                                break;
                        }
                    }
                    
                }
                

            }

            var search = tourFromDBs.Select(x => new TourModel
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

            return Ok(search);

        }
    }
}
