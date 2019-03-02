using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace devMeet.Dtos
{
    public class SeatRentalDto
    {
        public int SeatRentalId { get; set; }

        //public int SeatColumn { get; set; }
        //public int SeatRow { get; set; }
        public int SeatId { get; set; }

        public int MeetId { get; set; }

        public string DevName { get; set; }
        public string DevEmail { get; set; }

    }
}