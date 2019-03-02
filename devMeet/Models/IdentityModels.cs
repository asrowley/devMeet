using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace devMeet.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<SeatRental> SeatRentals { get; set; }
    }

    public class SeatRental
    {
        //joining table
        public int SeatRentalId { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int SeatId { get; set; }
        public Seat Seat { get; set; }

        public int MeetId { get; set; }
        public Meet Meet { get; set; }


        public string DevName { get; set; }
        public string DevEmail { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool UserHasPaid { get; set; }
    }

    public class Seat
    {
        public int SeatId { get; set; }
        public Column Column { get; set; }
        public Row Row { get; set; }

        public ICollection<SeatRental> SeatRentals { get; set; }
    }

    public enum Column
    {
        A = 1, B, C, D, E, F, G, H, I, J
    }

    public enum Row
    {
        One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten
    }

    public class Meet
    {
        public int MeetId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int? Price { get; set; }

        public ICollection<SeatRental> SeatRentals { get; set; }
    }



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