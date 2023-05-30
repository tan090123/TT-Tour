namespace BookingTravel.Models
{
    public class TourModel
    {
        public int TourID { get; set; }
        public string? TourCode { get; set; }
        public string? TourName { get; set; }
        public string? TourImage { get; set; }
        public int TourImageID { get; set; }
        public string? Departure { get; set; }
        public int Price { get; set; }
        public int PromotionPrice { get; set; }
        public string? DiscountTour { get; set; }
        public string? Destination { get; set; }
        public string? Description { get; set; }
        public DateTime TourCheckinDays { get; set; }
        public DateTime TourCheckoutDays { get; set; }
        public int TourTotalSit { get; set; }
        public int TourAvailableSit { get; set; }
        public int TourType { get; set; }

    }
}
