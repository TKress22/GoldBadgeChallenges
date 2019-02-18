using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    class Meal
    {
        int MealNumber { get; set; }
        string MealName { get; set; }
        string MealDescription { get; set; }
        string MealIngredients { get; set; }
        float MealPrice { get; set; }

        public Meal(int num, string name, string desc, string ings, float price)
        {
            MealNumber = num;
            MealName = name;
            MealDescription = desc;
            MealIngredients = ings;
            MealPrice = price;
        }
    }
}