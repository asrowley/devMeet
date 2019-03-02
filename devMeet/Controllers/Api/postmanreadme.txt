Postman rest client examples

//GET
http://localhost:60375/api/seatrentals

//POST //for individual rental - currently commented out
http://localhost:60375/api/seatrentals
Header
Content-Type application/json
Raw Data JSON
{

    "SeatId": 5,
    "MeetId": 1,
    "DevName": "Genevieve",
    "DevEmail": "genevieve@genevieve.com",

}

//PUT
http://localhost:60375/api/seatrentals/7
Header
Content-Type application/json
{

  "SeatId": 3,
  "MeetId": 1,
  "DevName": "Frank",
  "DevEmail": "frank@frank.com"
}

//DELETE
http://localhost:60375/api/seatrentals/8

POST MANY

{
  "SeatRentalDtoA" : 
  {
    "SeatId": 4,
    "MeetId": 2,
    "DevName": "Geraldine",
    "DevEmail": "geraldine@geraldine.com",
  },
  "SeatRentalDtoB" : 
  {
    "SeatId": 5,
    "MeetId": 2,
    "DevName": "Harriett",
    "DevEmail": "harriett@harriett.com",
  },
  "SeatRentalDtoC" : 
  {
    "SeatId": 6,
    "MeetId": 2,
    "DevName": "Ian",
    "DevEmail": "ian@ian.com",
  },
  "SeatRentalDtoD" : 
  {
    "SeatId": 7,
    "MeetId": 2,
    "DevName": "joe",
    "DevEmail": "joe@joe.com",
  },
}
