using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("Tours")]
    public class Tour
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }

    }
}
