using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("Bookings")]
    public class Bookings
    {
        [Key]
        public int BookingID { get; set; }
        public int? TourID { get; set; }
        public int? TouristID { get; set; }
        public int? UserID { get; set; }
        public int? ExtraPrice { get; set; }
        public int? CurrentPrice { get; set; }
        public int? TotalPrice { get; set; }
        public string? Payment { get; set; }
        public string? Status { get; set; }
        public DateTime? TourCheckinDays { get; set; }
        public DateTime? TourCheckoutDays { get; set; }
        public string? Departure { get; set; }
        public string? Destination { get; set; }
        public string? BookingName { get; set; }
        public DateTime? BookingDay { get; set; }
    }
}
