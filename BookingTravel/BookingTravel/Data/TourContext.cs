using Microsoft.EntityFrameworkCore;

namespace BookingTravel.Data
{
    public class TourContext : DbContext
    {
        public TourContext(DbContextOptions<TourContext> options) : base(options)
        {
        }

        #region Dbset
        public DbSet<Tour>? Tours { get; set; }
        #endregion
    }
}
