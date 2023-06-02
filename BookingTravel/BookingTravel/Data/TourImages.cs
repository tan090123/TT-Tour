using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("TourImages")]
    public class TourImages
    {
        [Key]
        public int ImageID { get; set; }
        public string? Images { get; set; }
        public int? TourID{ get; set; }

    }
}
