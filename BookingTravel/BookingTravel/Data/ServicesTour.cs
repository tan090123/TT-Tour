using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("ServicesTour")]
    public class ServicesTour
    {
        [Key]
        public int ServicesTourID { get; set; }
        public int TourID { get; set; }
        public string ServicesTourName { get; set; }
        public string ServicesTourDesc { get; set; }
    }
}
