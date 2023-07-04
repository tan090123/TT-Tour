namespace BookingTravel.Models
{
    public class TouristModel
    {
        public int TouristID { get; set; }
        public int? TouristType { get; set; }
        public string? TouristName { get; set; }

        public string? TouristSex { get; set; }
        public DateTime? TouristDate { get; set; }
        public int? TouristPrice { get; set; }
        public int? ServicesPrice { get; set; }

        public int? BookingID { get; set; }

    }
}
