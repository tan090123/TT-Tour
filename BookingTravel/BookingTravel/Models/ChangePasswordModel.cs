namespace BookingTravel.Models
{
    public class ChangePasswordModel
    {
        public int UserID { get; set; }
        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }
    }
}
