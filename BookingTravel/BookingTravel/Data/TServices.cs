using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("TServices")]
    public class TServices
    {
        [Key]
        public int TServicesID { get; set; }
        public string ServicesName { get; set; }
        public int ServicesPrice { get; set; }
    }
}
