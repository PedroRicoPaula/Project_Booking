using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Menus;

/* Booking Reservations on the Console
 * 
 * Create an Hotel
 *  -- Title --
 *  1 -> (Id, Name, Rooms, Capacity per room, price)
 *  2 -> Go Back (Painel)
 *  Choose Option:
 *  
 * Show Hotels
 *  -- Title --
 *  1 -> Name of the Hotel
 *  2 -> Name of the Hotel
 *  3 -> Go Back (Painel)
 * Choose Option:
 * 
 * Make Reservation
 *  -- Title --
 *  1 -> Choose Hotel -> Which room, number of person, Breakfast (y/n)
 *  2 -> Go Back (Painel)
 *  Choose Option:
 *  
 * Show Reservations
 *  -- Title --
 *  1 -> (Which Hotel Name, and details)
 *  2 -> Go Back (Painel)
 *  Choose Option:
 * 
 * Panel Options
 *  -- Title --
 *  1 -> Create Hotel
 *  2 -> Chose Hotel -> (Number of options) -> Make Reservation
 *  3 -> Show Reservations
 *  Choose Option:
 * 
 */



namespace Project_Booking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Hotel> hotels = new List<Hotel>();
            List<Reservation> reservations = new List<Reservation>();

            List<string> menu = new List<string>() { "Hotel Management", "Exit" };

            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("-- Welcome --\n");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i]}");
                }

                Console.Write("Choose one: ");
                var userInput1 = Console.ReadLine();

                if (int.TryParse(userInput1, out int choice) && choice >= 1 && choice <= menu.Count)
                {
                    switch (choice)
                    {
                        case 1:
                            HotelMenu.ShowHotelMenu(hotels, reservations);
                            break;
                        case 2:
                            showMenu = false;
                            Console.WriteLine("Exiting... Goodbye!");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                }
            }
        }
    }
}

