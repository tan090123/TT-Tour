using BookingTravel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace BookingTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private static List<TourModel> tours = new List<TourModel>();

        [HttpGet]
        public List<TourModel> SearchTravel([FromQuery] string? searchName)
        {
            if(tours.Count == 0)
            {
                var TravelSG = new TourModel();
                TravelSG.Id = 1;
                TravelSG.Name = "Tour Hồ Chí Minh";
                TravelSG.Departure = "Hà Nội";
                TravelSG.Destination = "Hồ Chí Minh";
                TravelSG.Description = "Tour du lịch từ Hà Nội đến Hồ Chí Minh khám phá nhiều nơi đẹp và thức ăn";
                TravelSG.Price = 3000000;
                TravelSG.Start_date = "10-05-2023";
                TravelSG.End_date = "14-05-2023";

                tours.Add(TravelSG);

                var TravelHN = new TourModel();
                TravelHN.Id = 2;
                TravelHN.Name = "Tour Hà Nội";
                TravelHN.Departure = "Hồ Chí Minh";
                TravelHN.Destination = "Hà Nội";
                TravelHN.Description = "Tour du lịch từ Hồ Chí Minh đến Hà Nội khám phá cảnh quan và thức ăn đặc sản thủ đô Hà Nội";
                TravelHN.Price = 5000000;
                TravelHN.Start_date = "10-05-2023";
                TravelHN.End_date = "15-05-2023";

                tours.Add(TravelHN);
            }

            if(searchName != null)
            {
                var searchResult = tours.Where(x => RemoveDiacritics(x.Name).IndexOf(RemoveDiacritics(searchName), StringComparison.InvariantCultureIgnoreCase) >= 0).ToList();
                return searchResult;
            } 
            else
            {
                return tours;
            }

        }

        // Hàm RemoveDiacritics để loại bỏ dấu diacritic
        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        // Thêm tour du lịch
        [HttpPost]
        public AddTourResultModel AddHotel([FromBody] TourModel newHotel)
        {
            var response = new AddTourResultModel();

            tours.Add(newHotel);

            response.Result = true;

            return response;
        }

        [HttpPut("{id:int}")]
        public UpdateTourResultModel UpdateHotel([FromRoute] int id, [FromBody] TourModel updateHotel)
        {
            var response = new UpdateTourResultModel();

            var tour = tours.Where(x => x.Id == id)
                .FirstOrDefault();

            if (tour == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                tour.Name = updateHotel.Name;
                tour.Departure = updateHotel.Departure;
                tour.Destination = updateHotel.Destination;
                tour.Description = updateHotel.Description;
                tour.Price = updateHotel.Price;
                tour.Start_date = updateHotel.Start_date;
                tour.End_date = updateHotel.End_date;
            }

            return response;
        }

        [HttpDelete("{id:int}")]
        public UpdateTourResultModel DeleteHotel([FromRoute] int id)
        {
            var response = new UpdateTourResultModel();

            var tour = tours.Where(x => x.Id == id)
                .FirstOrDefault();

            if (tour == null)
            {
                response.Result = false;
                response.ErrorMessage = "Không có Id nào là #" + id;
            }
            else
            {
                response.Result = true;

                tours.Remove(tour);
            }

            return response;
        }


    }
}
