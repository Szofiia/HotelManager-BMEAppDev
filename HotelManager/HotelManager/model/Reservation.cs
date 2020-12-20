using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManager.model
{
    public class Reservation
    {

        public long Id { get; set; }
        public List<Guest> Guests { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public Room Room { get; set; }

        public Reservation()
        {
            Guests = new List<Guest>();
        }

        // Only for testing purpose
        public Reservation(long id, List<Guest> guests, DateTime arrival, DateTime departure, Room room)
        {
            Id = id;
            Guests = guests;
            Arrival = arrival;
            Departure = departure;
            Room = room;
        }

    }
}
