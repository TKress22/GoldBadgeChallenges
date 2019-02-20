using System;
using System.Collections.Generic;
using Challenge_01;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Challenge_01_Test
{
    [TestClass]
    public class Challenge_01Tests
    {
        MenuRepository MenuRepo = new MenuRepository();

        [TestMethod]
        public void AddMealAndRetrieveItemTest()
        {
            Meal testMeal = new Meal(1, "chicken sticks", "sticks of chicken", "sticks, chicken, salt", 5.99f);

            MenuRepo.AddMeal(testMeal);

            Meal expected = testMeal;
            Meal actual = MenuRepo.RetrieveMenuItem(testMeal.MealNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveMealAndGetMenuTest()
        {
            Dictionary<int, Meal> Menu = MenuRepo.GetMenu();
            Meal testMeal = new Meal(1, "chicken sticks", "sticks of chicken", "sticks, chicken, salt", 5.99f);
            Meal testMealTwo = new Meal(2, "salt cookies", "salty cookies", "flour, salt, eggs", 1.99f);

            MenuRepo.AddMeal(testMeal);
            MenuRepo.AddMeal(testMealTwo);

            MenuRepo.RemoveMeal(testMealTwo.MealNumber);

            var actual = Menu.ContainsValue(testMealTwo);

            Assert.IsFalse(actual);

        }
    }
}