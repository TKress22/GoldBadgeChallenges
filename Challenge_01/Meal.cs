using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    class Meal
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; }
        public float MealPrice { get; set; }

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