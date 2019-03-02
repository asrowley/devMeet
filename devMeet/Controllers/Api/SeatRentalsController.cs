using devMeet.Dtos;
using devMeet.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace devMeet.Controllers.Api
{
    public class SeatRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public SeatRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/seatrentals
        public IHttpActionResult GetSeatRentals()
        {
            var seatRentals = _context.SeatRentals.ToList();
            return Ok(seatRentals);
        }

        //GET /api/seatrentals/1
        public IHttpActionResult GetSeatRental(int id)
        {
            var seatRental = _context.SeatRentals.SingleOrDefault(s => s.SeatRentalId == id);
            return Ok(seatRental);
        }

        //POST /api/seatrentals //allows only one booking per 'transaction'
        //[HttpPost]
        //public IHttpActionResult CreateSeatRental(SeatRentalDto seatRentalDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var currentUserId = User.Identity.GetUserId();
        //    //for testing in Postman
        //    var testUser = _context.Users.SingleOrDefault(u => u.Email == "abc@abc.com");

        //    var seatRental = new SeatRental
        //    {
        //        TimeStamp = DateTime.Now,
        //        //ApplicationUserId = currentUserId,
        //        //for testing in postman client
        //        ApplicationUserId = testUser.Id,
        //        DevEmail = seatRentalDto.DevEmail,
        //        DevName = seatRentalDto.DevName,
        //        MeetId = seatRentalDto.MeetId,
        //        //REQ: At the point of booking a person will select which seats they want, seats are not automatically allocated.
        //        SeatId = seatRentalDto.SeatId,
        //        UserHasPaid = false,

        //    };

//        //REQ: Two people must not be able to book the same seat at the same meet.
//        //logic to be moved elsewhere
//        var forbiddenSeatList = _context.SeatRentals
//            .Where(s => s.SeatId == seatRental.SeatId && s.MeetId == seatRental.MeetId);

//        //REQ: A unique name and email address are required for each seat that is booked
//        var forbiddenPersonList = _context.SeatRentals
//            .Where(s => (s.DevEmail == seatRental.DevEmail
//            || s.DevName == seatRental.DevName) && s.MeetId == seatRental.MeetId);


//        bool isEmpty = !forbiddenSeatList.Any();
//        bool personListisEmpty = !forbiddenPersonList.Any();

//            if (isEmpty && personListisEmpty)
//            {
//                _context.SeatRentals.Add(seatRental);
//                _context.SaveChanges();
//            }
//            else
//            {
//                return BadRequest(); //probably could be better here...
//}


//    seatRentalDto.SeatRentalId = seatRental.SeatRentalId;

//    return Created(new Uri(Request.RequestUri + "/" + seatRental.SeatRentalId), seatRentalDto);
//}

//PUT /api/seatrentals/1

        [HttpPut]
        public IHttpActionResult UpdateSeatRental(int id, SeatRentalDto seatRentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var seatRentalInDb = _context.SeatRentals.SingleOrDefault(s => s.SeatRentalId == id);

            if (seatRentalInDb == null)
                return NotFound();

            var currentUserId = User.Identity.GetUserId();
            //for testing in Postman
            var testUser = _context.Users.SingleOrDefault(u => u.Email == "abc@abc.com");

            //if (seatRentalInDb.ApplicationUserId != currentUserId) //actual code for live

            //for testing in postman
            if (seatRentalInDb.ApplicationUserId != testUser.Id)
                return BadRequest();

            seatRentalInDb.TimeStamp = DateTime.Now;
            seatRentalInDb.DevEmail = seatRentalDto.DevEmail;
            seatRentalInDb.DevName = seatRentalDto.DevName;
            seatRentalDto.MeetId = seatRentalDto.MeetId;
            seatRentalInDb.UserHasPaid = false;

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/seatrentals/1
        [HttpDelete]
        public IHttpActionResult DeleteSeatRental(int id)
        {
            var seatRentalInDb = _context.SeatRentals.SingleOrDefault(s => s.SeatRentalId == id);

            if (seatRentalInDb == null)
                return NotFound();

            _context.SeatRentals.Remove(seatRentalInDb);
            _context.SaveChanges();

            return Ok();
        }

        //Allows Four seats to be booked in one transaction
        //POST /api/seatrentals
        [HttpPost]
        public IHttpActionResult CreateSeatRentalList(SeatRentalDtoObject seatRentalDtoObject)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //REQ: A single person may book up to four seats in one transaction. But what is classed as a 'single transaction'?
            var srList = new List<SeatRentalDto>();

            SeatRentalDto srA;
            SeatRentalDto srB;
            SeatRentalDto srC;
            SeatRentalDto srD;

            //check for null values so user can book less than 4 in a transaction
            if (seatRentalDtoObject.SeatRentalDtoA != null)
            {
                srA = seatRentalDtoObject.SeatRentalDtoA;
                srList.Add(srA);
            }
                
            if (seatRentalDtoObject.SeatRentalDtoB != null)
            {
                srB = seatRentalDtoObject.SeatRentalDtoB;
                srList.Add(srB);
            }

            if (seatRentalDtoObject.SeatRentalDtoC != null)
            {
                srC = seatRentalDtoObject.SeatRentalDtoC;
                srList.Add(srC);
            }

            if (seatRentalDtoObject.SeatRentalDtoD != null)
            {
                srD = seatRentalDtoObject.SeatRentalDtoD;
                srList.Add(srD);
            }


            foreach(var sr in srList)
            {
                var testUser = _context.Users.SingleOrDefault(u => u.Email == "abc@abc.com");

                //    var currentUserId = User.Identity.GetUserId(); // if testing through the application

                var seatRental = new SeatRental
                {
                    TimeStamp = DateTime.Now,
                    //ApplicationUserId = currentUserId,
                    //for testing in postman client
                    ApplicationUserId = testUser.Id,
                    DevEmail = sr.DevEmail,
                    DevName = sr.DevName,
                    MeetId = sr.MeetId,
                    //REQ: At the point of booking a person will select which seats they want, seats are not automatically allocated.
                    SeatId = sr.SeatId,
                    UserHasPaid = false,

                };

                //logic to be moved elsewhere
                //REQ: Two people must not be able to book the same seat at the same meet.
                var forbiddenSeatList = _context.SeatRentals
                    .Where(s => s.SeatId == seatRental.SeatId && s.MeetId == seatRental.MeetId);

                //REQ: A unique name and email address are required for each seat that is booked (per meetup)
                var forbiddenPersonList = _context.SeatRentals
                    .Where(s => (s.DevEmail == seatRental.DevEmail
                    || s.DevName == seatRental.DevName) && s.MeetId == seatRental.MeetId);


                bool isEmpty = !forbiddenSeatList.Any();
                bool personListisEmpty = !forbiddenPersonList.Any();

                if (isEmpty && personListisEmpty)
                {
                    _context.SeatRentals.Add(seatRental);  
                }
                else
                {
                    return BadRequest(); //probably could be better here...
                }
               
            }
            _context.SaveChanges();
            return Ok();
        }

    }

       
}
