using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    public class MenuRepository
    {
        Dictionary<int, Meal> Menu = new Dictionary<int, Meal>();
        
        public void AddMeal(Meal mea)
        {
            Menu.Add(mea.MealNumber, mea);
        }
        public void RemoveMeal(int ind)
        {
            Menu.Remove(ind);
        }
        public Meal RetrieveMenuItem(int ind)
        {
            return Menu[ind];
        }
        public Dictionary<int, Meal> GetMenu()
        {
            return Menu;
        }
    }
}