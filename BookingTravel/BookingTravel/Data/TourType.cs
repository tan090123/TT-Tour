using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("TourType")]
    public class TourType
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }

    }
}
