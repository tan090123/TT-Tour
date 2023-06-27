using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTravel.Data
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        //public string Address { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
