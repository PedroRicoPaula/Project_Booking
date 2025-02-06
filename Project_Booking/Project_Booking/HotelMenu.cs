using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using Classes;

namespace Menus
{
    public static class HotelMenu
    {
        public static void ShowHotelMenu(List<Classes.Hotel> hotels, List<Classes.Reservation> reservations)
        {
            List<string> menuOptions = new List<string> { "Create", "View", "Make Reservation", "Show Reservations", "Go back" };
            bool showHotelMenu = true;

            while (showHotelMenu)
            {
                Console.Clear();
                Console.WriteLine("-- Hotels --\n");
                for (int i = 0; i < menuOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menuOptions[i]}");
                }

                Console.Write("Choose one: ");
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int choice) && choice >= 1 && choice <= menuOptions.Count)
                {
                    switch (choice)
                    {
                        case 1:
                            CreateHotels(hotels);
                            break;
                        case 2:
                            ViewHotels(hotels);
                            break;
                        case 3:
                            MakeReservation(hotels, reservations);
                            break;
                        case 4:
                            ShowReservations(reservations);
                            break;
                        case 5:
                            showHotelMenu = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                }
            }
        }

        private static void CreateHotels(List<Classes.Hotel> hotels)
        {
            Console.Clear();
            Console.WriteLine("-- Create a Hotel --\n");

            string name = ReadInput("Name: ");
            int rooms = ReadIntInput("Rooms: ");
            int capacityRoom = ReadIntInput("Capacity per Room: ");
            float price = ReadFloatInput("Price (€): ");

            hotels.Add(new Classes.Hotel(name, rooms, capacityRoom, price));

            Console.WriteLine("\nHotel created successfully!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        private static void ViewHotels(List<Classes.Hotel> hotels)
        {
            Console.Clear();
            Console.WriteLine("-- List of Hotels --\n");

            if (hotels.Count == 0)
            {
                Console.WriteLine("No hotels have been created yet.");
                Console.WriteLine("\nPress any key to return...");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < hotels.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {hotels[i].Name}");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        private static void MakeReservation(List<Classes.Hotel> hotels, List<Classes.Reservation> reservations)
        {
            Console.Clear();
            Console.WriteLine("-- Make a Reservation --\n");

            if (hotels.Count == 0)
            {
                Console.WriteLine("No hotels available. Create a hotel first.");
                Console.WriteLine("\nPress any key to return...");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < hotels.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {hotels[i].Name}");
            }

            Console.Write("Choose a hotel: ");
            int hotelChoice = ReadIntInput("") - 1;

            if (hotelChoice < 0 || hotelChoice >= hotels.Count)
            {
                Console.WriteLine("Invalid hotel choice. Press any key to return...");
                Console.ReadKey();
                return;
            }

            Console.Write("Choose room number: ");
            int roomNumber = ReadIntInput("");
            Console.Write("Number of guests: ");
            int numberOfGuests = ReadIntInput("");
            Console.Write("Include breakfast? (y/n): ");
            bool breakfastIncluded = Console.ReadLine()?.ToLower() == "y";

            reservations.Add(new Classes.Reservation(hotels[hotelChoice].Name, roomNumber, numberOfGuests, breakfastIncluded));

            Console.WriteLine("\nReservation created successfully!");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        private static void ShowReservations(List<Classes.Reservation> reservations)
        {
            Console.Clear();
            Console.WriteLine("-- Reservations --\n");

            if (reservations.Count == 0)
            {
                Console.WriteLine("No reservations have been made yet.");
                Console.WriteLine("\nPress any key to return...");
                Console.ReadKey();
                return;
            }

            foreach (var reservation in reservations)
            {
                Console.WriteLine(reservation);
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        private static string ReadInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? string.Empty;
        }

        private static int ReadIntInput(string message)
        {
            int value;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Please enter a valid integer: ");
            }
            return value;
        }

        private static float ReadFloatInput(string message)
        {
            float value;
            Console.Write(message);
            while (!float.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Please enter a valid float: ");
            }
            return value;
        }
    }
}