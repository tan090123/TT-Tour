namespace BookingTravel.Models
{
    public class TourGuideModel
    {
        public int GuideID { get; set; }
        public int TourID { get; set; }
        public string GuideName { get; set; }
        public string GuidePhone { get; set; }
        public string GuideAddress { get; set; }
    }
}
