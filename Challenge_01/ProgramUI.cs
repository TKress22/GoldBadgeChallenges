using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    class ProgramUI
    {
        bool Running = true;
        MenuRepository menuRepo = new MenuRepository();

        public void Run()
        {
            Console.WriteLine("Welcome to the Komodo Cafe Menu Program.");
            string resp;
            while (Running)
            {
                Console.WriteLine("Type: \n-'a' to add a new menu item \n-'d' to delete a menu item \n-'v' to view the menu \n-'x' to exit the program");
                Console.Write("Enter a selection: ");
                resp = Console.ReadLine().ToLower();
                switch (resp[0])
                {
                    case 'd':
                        Console.Clear();
                        RemoveMenuItem();
                        break;
                    case 'a':
                        Console.Clear();
                        AddMenuItem();
                        break;
                    case 'v':
                        Console.Clear();
                        ShowMenu();
                        break;
                    case 'x':
                        Running = false;
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Write("Invalid command");
                        break;
                }
            }
            Console.ReadLine();
        }
        public void AddMenuItem()
        {
            string itemName, itemDesc, itemIngs;
            int itemNum = 0;
            float itemPrice = 0.0f;
            bool valid = false;

            Console.WriteLine("Adding a new item:");

            Console.Write("Enter the item number: ");
            while (!valid)
            {
                valid = int.TryParse(Console.ReadLine(), out itemNum);
                if (!valid)
                {
                    Console.Write("Please enter a numerical value: ");
                }
            }

            Console.Write("Enter the name of the meal: ");
            itemName = Console.ReadLine();

            Console.Write("Enter the meal description: ");
            itemDesc = Console.ReadLine();

            Console.Write("Enter the meal ingredients: ");
            itemIngs = Console.ReadLine();

            Console.Write("Enter the meal price: ");
            valid = false;
            while (!valid)
            {
                valid = float.TryParse(Console.ReadLine(), out itemPrice);
                if (!valid)
                {
                    Console.Write("Please enter a numerical value: ");
                }
            }
            menuRepo.AddMeal(new Meal(itemNum, itemName, itemDesc, itemIngs, itemPrice));
            Console.WriteLine("Item added. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
        public void RemoveMenuItem()
        {
            int ind = -1;
            bool valid = false;

            Console.WriteLine("Removing a menu item: ");
            Console.Write("Enter the number of the meal to remove from the menu: ");
            while (!valid)
            {
                valid = int.TryParse(Console.ReadLine(), out ind);
                if (!valid)
                {
                    Console.Write("Please enter a numerical value: ");
                }
            }
            menuRepo.RemoveMeal(ind);
            Console.WriteLine("Item removed. Press enter to continue. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
        public void ShowMenu()
        {
            Dictionary<int, Meal> temp = menuRepo.GetMenu();
            Console.WriteLine("Menu: ");
            foreach(int r in temp.Keys)
            {
                Console.WriteLine("-#" + temp[r].MealNumber + " " + temp[r].MealName + " $" + temp[r].MealPrice + "\n \t-" + temp[r].MealDescription + "\n \t Ingredients: " +temp[r].MealIngredients);
            }
            Console.WriteLine("\n\n");
        }
        
    }
}