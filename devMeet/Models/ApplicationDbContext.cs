using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace devMeet.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<SeatRental> SeatRentals { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Meet> Meets { get; set; }

        //test
        public DbSet<Test> Tests { get; set; }

    }
}