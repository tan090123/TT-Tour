using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewsID { get; set; }
        public int UserID { get; set; }
        public int TourID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDay { get; set; }

    }
}
