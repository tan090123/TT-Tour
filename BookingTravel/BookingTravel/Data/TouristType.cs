using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("TouristType")]
    public class TouristType
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }

    }
}
