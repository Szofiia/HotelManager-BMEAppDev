using HotelManager.data;
using HotelManager.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManager.services
{
    class ReservationService
    {
        public IDataBase DataBase { get; set; }
        public List<Room> GetAvailableRooms(DateTime arrival, DateTime departure)
        {
            return DataBase.GetAvailableRooms(arrival, departure);
        }
        public bool ReserveForCustomer(Room room, List<Guest> guests, DateTime arrival, DateTime departure)
        {
            return true;
        }
        public int GetReservaionCost(long reservationId)
        {
            int cost = DataBase.GetCost();
            int childCost = DataBase.GetChildCost();

            Reservation reservation = DataBase.GetReservation(reservationId);

            int price = 0;
            reservation.Guests.ForEach(guest => price += guest.IsChild ? childCost : cost);
            int childCount = reservation.Guests.FindAll(guest => guest.IsChild).Count;

            return price;
        }
    }
}
