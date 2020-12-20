using HotelManager.data;
using HotelManager.model;
using HotelManager.services;
using System;
using System.Collections.Generic;

namespace HotelManager
{
    class Program
    {
        static char MainMenu() 
        {
            Console.WriteLine("\nHotel Reservation Manager");
            Console.WriteLine("Please chose from the following options:");

            Console.WriteLine("1. List available rooms");
            Console.WriteLine("2. Create Reservation");
            Console.WriteLine("3. List reservations");
            Console.WriteLine("4. Calculate price of booking");

            Console.WriteLine("Please enter the chosen number, or press Q to exit");

            return Console.ReadKey().KeyChar;
        }

        static char ListRooms(ReservationService reservationService)
        {
            Console.WriteLine("\nPlease type the arrival date in the format of: mm/dd/yyyy");
            string arrivalStr = Console.ReadLine();

            Console.WriteLine("Please type the departure date in the format of: mm/dd/yyyy");
            string departureStr = Console.ReadLine();

            List<Room> availableRooms = reservationService.GetAvailableRooms(DateTime.Parse(arrivalStr), DateTime.Parse(departureStr));

            if (availableRooms.Count == 0) {

                Console.WriteLine("There are no available rooms. Return to Main menu with M");
                return Console.ReadKey().KeyChar;
            }
            Console.WriteLine("Available rooms:");
            availableRooms.ForEach(room => Console.WriteLine("Room: {0} FREE", room.RoomNumber));

            Console.WriteLine("Return to Main menu with M");
            return Console.ReadKey().KeyChar;
        }

        static char CreateReservation(ReservationService reservationService)
        {

            Console.WriteLine("\nPlease type the arrival date in the format of: mm/dd/yyyy");
            string arrivalStr = Console.ReadLine();

            Console.WriteLine("Please type the departure date in the format of: mm/dd/yyyy");
            string departureStr = Console.ReadLine();

            Console.WriteLine("Please type the room number");
            string roomNo = Console.ReadLine();
            
            bool isAvailable = reservationService.isRoomAvailabe(int.Parse(roomNo));

            if (!isAvailable)
            {
                Console.WriteLine("Room not available. Return to Main Menu with M");
                return Console.ReadKey().KeyChar;
            }

            Console.WriteLine("Please type guests!");
            List<Guest> guests = new List<Guest>();
            char quitAddGuests = '0';
            while (quitAddGuests != 'L')
            {
                Console.WriteLine("Please type the first name of the new guest!");
                string firstName = Console.ReadLine();

                Console.WriteLine("Please type the last name of the new guest!");
                string lastName = Console.ReadLine();

                Console.WriteLine("Please type the birth date of the new guest!");
                string birthDate = Console.ReadLine();

                Console.WriteLine("Please type 0 if new guest is child!");
                string child = Console.ReadLine();
                bool isChild;
                if (child == "0") {
                    isChild = true;
                }
                isChild = false;

                Guest newGuest = new Guest();
                newGuest.FirstName = firstName;
                newGuest.LastName = lastName;
                newGuest.BirthDate = birthDate;
                newGuest.IsChild = isChild;

                guests.Add(newGuest);

                Console.WriteLine("Please type 'L' if this is the last guest!");
                quitAddGuests = Console.ReadKey().KeyChar;
            }


            Console.WriteLine("Return to Main Menu with M");
            return Console.ReadKey().KeyChar;
        }

        static char ListReservations(ReservationService reservationService)
        {

            Console.WriteLine("\nList of reservations:");
            Console.WriteLine("--------------------------------------------------------------------");
            List<Reservation> reservations = reservationService.GetReservations();
            reservations.ForEach(res => Console.WriteLine("ID: {0} | Arrival:  {1} | Departure:  {2} | Room: {3}", 
                res.Id, res.Arrival.ToString(), res.Departure.ToString(), res.Room.RoomNumber));

            return Console.ReadKey().KeyChar;
        }

        static char GetReservationCost(ReservationService reservationService)
        {

            Console.WriteLine("\nPlease enter reservation ID:");
            string reservationId = Console.ReadLine();
            int cost = reservationService.GetReservaionCost(long.Parse(reservationId));
            Console.WriteLine("The complete reservation cost is {0}", cost);

            Console.WriteLine("Return to Main menu with M");
            return Console.ReadKey().KeyChar;
        }

        static void Main(string[] args)
        {
            LocalDataBase database = new LocalDataBase();
            database.Cost = 5000;
            database.ChildCost = 2500;
            database.PushDummyData();
            ReservationService reservationService = new ReservationService(database);


            Boolean quit = false;
            char key = '0';

            while (!quit)
            {
                switch (key)
                {
                    case '1':
                        key = ListRooms(reservationService);
                        break;

                    case '2':
                        key = CreateReservation(reservationService);
                        break;

                    case '3':
                        key = ListReservations(reservationService);
                        break;

                    case '4':
                        key = GetReservationCost(reservationService);
                        break;

                    case 'q':
                        quit = true;
                        break;

                    default: 
                        key = MainMenu();
                        break;
                }
            }

            
        }
    }
}
