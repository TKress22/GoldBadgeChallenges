﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    class MenuRepository
    {
        Dictionary<int, Meal> Menu = new Dictionary<int, Meal>();
        
        public void AddMeal(Meal mea)
        {

        }
        public void RemoveMeal(int ind)
        {

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