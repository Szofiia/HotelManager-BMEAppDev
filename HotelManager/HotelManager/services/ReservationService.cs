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
            
            if (GetAvailableRooms(arrival, departure).Contains(room))
            {
                Reservation newReservation = new Reservation();
                newReservation.Room = room;
                newReservation.Guests = guests;
                newReservation.Arrival = arrival;
                newReservation.Departure = departure;

                DataBase.AddReservation(newReservation);

                return true;
            }
            return false;
        }
        public int GetReservaionCost(long reservationId)
        {
            int cost = DataBase.GetCost();
            int childCost = DataBase.GetChildCost();

            Reservation reservation = DataBase.GetReservation(reservationId);

            int price = 0;
            reservation.Guests.ForEach(guest => price += guest.IsChild ? childCost : cost);

            return price;
        }
    }
}
