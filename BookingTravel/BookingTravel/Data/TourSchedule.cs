using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("TourSchedule")]
    public class TourSchedule
    {
        [Key]
        public int ScheduleID { get; set; }
        public int TourID { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleDesc { get; set; }
        public string ScheduleNote { get; set; }
    }
}
