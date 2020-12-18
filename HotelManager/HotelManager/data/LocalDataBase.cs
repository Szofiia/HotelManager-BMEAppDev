using HotelManager.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManager.data
{
    public class LocalDataBase : IDataBase
    {
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

        public List<Room> GetRooms()
        {
            return Rooms;
        }

        public Room GetRoomByNumber(int number)
        {
            return Rooms.First(room => room.RoomNumber == number);
        }

        public int GetChildCost()
        {
            return ChildCost;
        }
    }
}
