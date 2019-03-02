namespace devMeet.Migrations
{
    using devMeet.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<devMeet.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(devMeet.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //real entities

            #region Create Users

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                //var store = new RoleStore<IdentityRole>(context);
                //var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);

            }
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                //var store = new RoleStore<IdentityRole>(context);
                //var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };

                manager.Create(role);

            }

            if (!context.Users.Any(u => u.UserName == "admin@devMeet.com"))
            {
                
                var adminUser = new ApplicationUser { UserName = "admin@devMeet", Email = "admin@devMeet" };

                userManager.Create(adminUser, "P@ssword1");
                userManager.AddToRole(adminUser.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "abc@abc.com"))
            {

                var standardUser = new ApplicationUser { UserName = "abc@abc.com", Email = "abc@abc.com" };

                userManager.Create(standardUser, "P@ssword1");
                userManager.AddToRole(standardUser.Id, "User");
            }




            #endregion

            #region Seats

            var cols = new List<Column>
            {
                Column.A, Column.B, Column.C, Column.D,
                Column.E, Column.F, Column.G, Column.H,
                Column.I, Column.J
            };
            var rows = new List<Row>
            {
                Row.One, Row.Two, Row.Three, Row.Four,
                Row.Five, Row.Six, Row.Seven, Row.Eight,
                Row.Nine, Row.Ten
            };
            var seats = new List<Seat>();

            foreach (var col in cols)
            {
                foreach (var row in rows)
                {
                    var seat = new Seat
                    {
                        Column = col,
                        Row = row
                    };
                    seats.Add(seat);
                }
            }

            foreach (var seat in seats)
            {
                context.Seats.AddOrUpdate(s => s.SeatId, seat);
            }

            #endregion

            #region Meets

            var meets = new List<Meet>
            {
                new Meet
                {
                    MeetId = 1,
                    Location = "Eastleigh",
                    Date = new DateTime(2019, 4, 1)
                },
                new Meet
                {
                    MeetId = 2,
                    Location = "Eastleigh",
                    Date = new DateTime(2019, 5, 1)
                }
            };

            foreach (var meet in meets)
            {
                context.Meets.AddOrUpdate(m => m.MeetId, meet);
            }

            #endregion


            //joining table
            #region SeatRentals

            var now = DateTime.Now;
            var user = context.Users.SingleOrDefault(u => u.Email == "abc@abc.com");
           
            var seatRentals = new List<SeatRental>
            {
                new SeatRental
                {
                    SeatRentalId = 1,
                    SeatId = 1,
                    ApplicationUserId = user.Id,
                    MeetId = 1,
                    DevName = "Andy",
                    DevEmail = "andy@andy.com",
                    TimeStamp = DateTime.Now,
                    UserHasPaid = false

                },
                new SeatRental
                {
                    SeatRentalId = 2,
                    SeatId = 2,
                    ApplicationUserId = user.Id,
                    MeetId = 1,
                    DevName = "Bob",
                    DevEmail = "bob@bob.com",
                    TimeStamp = DateTime.Now,
                    UserHasPaid = false

                },
                new SeatRental
                {
                    SeatRentalId = 3,
                    SeatId = 3,
                    ApplicationUserId = user.Id,
                    MeetId = 1,
                    DevName = "Clarice",
                    DevEmail = "clarice@clarice.com",
                    TimeStamp = DateTime.Now,
                    UserHasPaid = false
                },
                new SeatRental
                {
                    SeatRentalId = 4,
                    SeatId = 1,
                    ApplicationUserId = user.Id,
                    MeetId = 2,
                    DevName = "Clarice",
                    DevEmail = "clarice@clarice.com",
                    TimeStamp = DateTime.Now,
                    UserHasPaid = false
                },
            };

            foreach (var seatRental in seatRentals)
            {
                context.SeatRentals.AddOrUpdate(sr => sr.SeatRentalId, seatRental);
            };

            #endregion

        }
    }
}
