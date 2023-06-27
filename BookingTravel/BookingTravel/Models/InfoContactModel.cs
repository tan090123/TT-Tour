namespace BookingTravel.Models
{
    public class InfoContactModel
    {
        public int ContactID { get; set; }
        public int TourID { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactAddress { get; set; }
        public string? ContactNote { get; set; }

    }
}
