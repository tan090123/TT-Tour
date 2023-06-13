using System.ComponentModel.DataAnnotations;

namespace BookingTravel.Models
{
    public class TouristType_priceModel
    {
        [Key]
        public int TypeID { get; set; }
        public string? TouristTypeName { get; set; }
        public int? tourID { get; set; }

        public decimal? touristType_Prices { get; set; }
    }
}
