using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("Tourist")]
    public class Tourist
    {
        [Key]
        public int TouristID { get; set; }
        public int? TourID { get; set; }
        public int? TouristType { get; set; }
        public string? TouristSex { get; set; }
        public DateTime? TouristDate { get; set; }
        public int? TouristPrice { get; set; }
        public string? TouristNote { get; set; }
        public int? ServicesPrice { get; set; }

    }
}
