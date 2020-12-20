using HotelManager.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManager.data
{
    public class LocalDataBase : IDataBase
    {
        public int Cost;
        public int ChildCost;
        public List<Guest> Guests { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Reservation> Reservations { get; set; }

        public LocalDataBase()
        {
            Guests = new List<Guest>();
            Rooms = new List<Room>();
            Reservations = new List<Reservation>();
        }

        public void AddGuest(Guest guest)
        {
            Guests.Add(guest);
        }

        public void AddReservation(Reservation reservation)
        {
            Reservations.Add(reservation);
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public List<Room> GetAvailableRooms(DateTime arrival, DateTime departure)
        {
            return Rooms.FindAll(room => room.Reservations.All(res => res.Departure <= arrival || res.Arrival >= departure));
        }

        public Room GetByNumber(int number)
        {
            return Rooms.First(room => room.RoomNumber == number);
        }

        public Reservation GetReservation(long reservationId)
        {
            return Reservations.Find(res => res.Id == reservationId);
        }

        public List<Reservation> GetReservations()
        {
            return Reservations;
        }

        public List<Room> GetRooms()
        {
            return Rooms;
        }

        public bool IsRoomAvailable(int number)
        {
            int roomIndex = Rooms.FindIndex(room => room.RoomNumber == number);
            if (roomIndex > -1) {
                return false;
            };
            return true;
        }

        public int GetChildCost()
        {
            return ChildCost;
        }

        public int GetCost()
        {
            return Cost;
        }

        public void PushDummyData() {
            List<Guest> dummyGuests = new List<Guest>();
            List<Room> dummyRooms = new List<Room>();
            List <Reservation> dummyReservations = new List<Reservation>();

            dummyGuests.Add(new Guest(0, "Steve", "Smith", "01.04.1975", false));
            dummyGuests.Add(new Guest(1, "Liu", "Smith", "01.04.1978", false));
            dummyGuests.Add(new Guest(2, "Jane", "Smith", "01.04.2008", true));

            dummyRooms.Add(new Room(0, 100, new List<Reservation>()));

            dummyReservations.Add(new Reservation(0, dummyGuests, new DateTime(2020, 12, 10), new DateTime(2020, 12, 14), dummyRooms[0]));

            dummyRooms[0].Reservations.Add(dummyReservations[0]);

            dummyGuests.Add(new Guest(3, "James", "Cook", "11.07.1980", false));
            dummyGuests.Add(new Guest(4, "Peter", "Pan", "01.01.1901", true));
            dummyGuests.Add(new Guest(5, "Wendy", "Smith", "05.05.2010", true));
            
            dummyRooms.Add(new Room(2, 101, new List<Reservation>()));
            dummyRooms.Add(new Room(3, 102, new List<Reservation>()));
            dummyRooms.Add(new Room(4, 103, new List<Reservation>()));


            Guests = dummyGuests;
            Rooms = dummyRooms;
            Reservations = dummyReservations;
        }
    }
}
