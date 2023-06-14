using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookingTravel.Data
{
    public class TourContext : DbContext
    {
        public TourContext(DbContextOptions<TourContext> options) : base(options)
        {
        }

        #region Dbset
        public DbSet<Tours> Tours { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersRole> UsersRole { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<InfoContact> InfoContact { get; set; }
        public DbSet<TServices> TServices { get; set; }
        public DbSet<ServicesTour> ServicesTour { get; set; }
        public DbSet<Tourist> Tourist { get; set; }
        public DbSet<TouristServices> TouristServices { get; set; }
        public DbSet<TourGuide> TourGuide { get; set; }
        public DbSet<TourType> TourType { get; set; }
        public DbSet<TouristType_price> TouristType_price { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<TourImages> TourImages { get; set; }
        public DbSet<TourSchedule> TourSchedule { get; set; }

        #endregion
    }
}
