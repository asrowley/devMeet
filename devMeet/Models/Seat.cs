using System.Collections.Generic;

namespace devMeet.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public Column Column { get; set; }
        public Row Row { get; set; }

        public ICollection<SeatRental> SeatRentals { get; set; }
    }
}