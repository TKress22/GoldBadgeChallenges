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
            Console.ReadLine();
        }
        public void PrintMenu()
        {

        }
        
    }
}