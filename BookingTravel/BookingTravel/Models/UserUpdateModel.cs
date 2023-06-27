namespace BookingTravel.Models
{
    public class UserUpdateModel
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }

    }
}
