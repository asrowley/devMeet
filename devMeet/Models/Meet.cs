using System;
using System.Collections.Generic;

namespace devMeet.Models
{
    public class Meet
    {
        public int MeetId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int? Price { get; set; }

        public ICollection<SeatRental> SeatRentals { get; set; }
    }
}