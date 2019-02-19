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
            menuRepo.AddMeal(new Meal(3, "chicken sticks", "sticks of chicken", "chicken, sticks", 5.99f));
            menuRepo.AddMeal(new Meal(1, "ye", "ey", "y, e", 5.99f));
            menuRepo.AddMeal(new Meal(2, "yoi", "ioy", "y, o, i", 5.99f));
            ShowMenu();
            Console.ReadLine();
        }
        public void ShowMenu()
        {
            Dictionary<int, Meal> temp = menuRepo.GetMenu();
            Console.WriteLine("Menu: ");
            foreach(int r in temp.Keys)
            {
                Console.WriteLine("-#" + temp[r].MealNumber + " " + temp[r].MealName + " $" + temp[r].MealPrice + "\n \t-" + temp[r].MealDescription);
            }
        }
        
    }
}