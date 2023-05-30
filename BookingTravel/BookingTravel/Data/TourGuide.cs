using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("TourGuide")]
    public class TourGuide
    {
        [Key]
        public int GuideID { get; set; }
        public int TourID { get; set; }
        public string GuideName { get; set; }
        public string GuidePhone { get; set; }
        public string GuideAddress { get; set; }

    }
}
