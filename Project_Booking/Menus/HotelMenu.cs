using System;
using System.Collections.Generic;
using Classes;

namespace Menus
{
    public static void ShowHotelMenu(List<Hotel> hotels)
    {
        List<string> menuOptions = new() { "Create", "View", "Go back" };
        bool showCarMenu = true;

        while (showCarMenu)
        {
            Console.Clear();
            Console.WriteLine("-- Cars --\n");
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
                        CreateCar(cars);
                        break;
                    case 2:
                        ViewCars(cars);
                        break;
                    case 3:
                        showCarMenu = false;
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
}
