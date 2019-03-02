using System;

namespace devMeet.Models
{
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
}