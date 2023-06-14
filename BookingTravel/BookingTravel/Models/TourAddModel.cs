namespace BookingTravel.Models
{
    public class TourAddModel
    {
        public string? TourCode { get; set; }
        public string? TourName { get; set; }
        public string? TourImage { get; set; }
        //public IFormFile? TourImage { get; set; }
        //public byte[] ImgByte { get; set; }
        public string? Departure { get; set; }
        public int? Price { get; set; }
        public int? PromotionPrice { get; set; }
        public string? DiscountTour { get; set; }
        public string? Destination { get; set; }
        public string? Description { get; set; }
        public DateTime? TourCheckinDays { get; set; }
        public DateTime? TourCheckoutDays { get; set; }
        public int? TourTotalSit { get; set; }
        public int? TourAvailableSit { get; set; }
        public int? TourType { get; set; }
        public int? tour_NumberDays { get; set; }
        public int? tour_AvalablePeople { get; set; }

    }
}
