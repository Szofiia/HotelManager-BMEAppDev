using System;
using System.Collections.Generic;
using System.Text;
using HotelManager.model;

namespace HotelManager.data
{
    public interface IDataBase
    {
        void AddGuest(Guest guest);
        void AddReservation(Reservation reservation);
        void AddRoom(Room room);
        List<Room> GetAvailableRooms(DateTime arrival, DateTime departure);
        List<Room> GetRooms();
        Reservation GetReservation(long reservationId);
        Room GetRoomByNumber(int number);
        int GetChildCost();
    }
}
