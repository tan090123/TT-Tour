using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("TouristType_price")]
    public class TouristType_price
    {
        [Key]
        public int TypeID { get; set; }
        public string? TouristTypeName { get; set; }
        public int? tourID { get; set; }

        public decimal? touristType_Prices { get; set; }

    }
}
