using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManager.model
{
    public class Room
    {

        public long Id { get; set; }
        public int RoomNumber { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Room()
        {
            Reservations = new List<Reservation>();
        }

        // Only for testing purpose
        public Room(long id, int roomNumber, List<Reservation> reservations)
        {
            Id = id;
            RoomNumber = roomNumber;
            Reservations = reservations;
        }
        
    }
}
