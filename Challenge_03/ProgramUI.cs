using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03
{
    class ProgramUI
    {
        OutingRepository outingRepo = new OutingRepository();
        bool running = true;

        public void Run()
        {
            //Test data
            outingRepo.AddOuting(new Outing(OutingType.Bowling, 52, new DateTime(05, 05, 05), 15, 5000));
            outingRepo.AddOuting(new Outing(OutingType.Golf, 24, new DateTime(05, 05, 05), 10, 7550));
            outingRepo.AddOuting(new Outing(OutingType.Concert, 85, new DateTime(05, 05, 05), 34, 6500));
            Console.WriteLine("Komodo Outing Program: \n");
            while (running)
            {
                Console.Write("Enter 'a' to add, 'v' to view outings, 't' for totals, or 'x' to close: ");

                switch (Console.ReadLine().ToLower()[0])
                {
                    case 'a':
                        AddOutingMenu();
                        break;
                    case 'v':
                        ViewOutingsMenu();
                        break;
                    case 't':
                        DisplayTotals();
                        break;
                    case 'x':
                        Console.WriteLine("Bye!");
                        running = false;
                        break;
                    default:
                        break;
                }
            }
            Console.ReadLine();
        }
        public void ViewOutingsMenu()
        {
            Console.WriteLine("List of outings: \n");
            foreach(var r in outingRepo.GetOutings())
            {
                Console.WriteLine("Outing type: " + r.EventType);
                Console.WriteLine("Outing attendance: " + r.AttendanceCount);
                Console.WriteLine("Outing date: " + r.Date);
                Console.WriteLine("Outing cost per person: " + r.CostPerPerson);
                Console.WriteLine("Outing total cost: " + r.TotalCost + "\n");

            }
        }
        public void AddOutingMenu()
        {
            bool valid = false;
            OutingType type = OutingType.Golf;
            int atnd = 0;
            DateTime date = new DateTime();
            double pCost = 0;
            double tCost = 0;
            
            Console.WriteLine("Add a new outing: \n");

            Console.Write("Enter the type of outing: ");
            while (!valid)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "golf":
                        type = OutingType.Golf;
                        valid = true;
                        break;
                    case "concert":
                        type = OutingType.Concert;
                        valid = true;
                        break;
                    case "bowling":
                        type = OutingType.Bowling;
                        valid = true;
                        break;
                    case "amusement park":
                        type = OutingType.AmusementPark;
                        valid = true;
                        break;
                    default:
                        Console.Write("Invalid type. Types are (Golf, Concert, Bowling, Amusement Park): ");
                        break;
                }
            }
            valid = false;

            Console.Write("Enter the number of people who attended: ");
            while (!valid)
            {
                valid = int.TryParse(Console.ReadLine(), out atnd);
                if (!valid)
                {
                    Console.Write("Please enter a numerical value: ");
                }
            }
            valid = false;

            Console.Write("Enter the outing date: ");
            while (!valid)
            {
                valid = DateTime.TryParse(Console.ReadLine(), out date);
                if (!valid)
                {
                    Console.Write("Please enter a valid date (mm/dd/yy): ");
                }
            }
            valid = false;

            Console.Write("Enter the cost per person: ");
            while (!valid)
            {
                valid = double.TryParse(Console.ReadLine(), out pCost);
                if (!valid)
                {
                    Console.Write("Please enter a numerical value: ");
                }
            }
            valid = false;

            Console.Write("Enter the total cost: ");
            while (!valid)
            {
                valid = double.TryParse(Console.ReadLine(), out tCost);
                if (!valid)
                {
                    Console.Write("Please enter a numerical value: ");
                }
            }

            outingRepo.AddOuting(new Outing(type, atnd, date, pCost, tCost));
            Console.WriteLine("Outing added.\n");
        }
        public void DisplayTotals()
        {
            Console.WriteLine("Totals: \n");
            Console.WriteLine("Total outing costs: $" + outingRepo.GetGrandTotal());
            Console.WriteLine("\nBroken down by type: \n");
            Console.WriteLine("Golfing Costs: $" + outingRepo.GetTotalByType(OutingType.Golf));
            Console.WriteLine("Bowling Costs: $" + outingRepo.GetTotalByType(OutingType.Bowling));
            Console.WriteLine("Concert Costs: $" + outingRepo.GetTotalByType(OutingType.Concert));
            Console.WriteLine("Amusement Park Costs: $" + outingRepo.GetTotalByType(OutingType.AmusementPark));

        }
    }
}