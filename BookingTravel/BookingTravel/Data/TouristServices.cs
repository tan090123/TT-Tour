using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("TouristServices")]
    public class TouristServices
    {
        [Key]
        public int ServicesID { get; set; }
        public int TouristID { get; set; }
        public int TServicesID { get; set; }
    }
}
