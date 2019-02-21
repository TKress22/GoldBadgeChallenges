using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04
{
    public class ProgramUI
    {
        BadgeRepository badgeRepo = new BadgeRepository();
        bool running = true;

        public void Run()
        {
            //Test data
            badgeRepo.AddBadge(new Badge(123, new List<string> { "A1", "A2", "A3" }));
            badgeRepo.AddBadge(new Badge(223, new List<string> { "B1", "B2"}));
            badgeRepo.AddBadge(new Badge(323, new List<string> { "C3" }));

            Console.WriteLine("Welcome, security admin.\n Enter 'a' to add a badge, 'v' to view badges, 'e' to edit a badge, or 'x' to exit.");
            while (running)
            {
                Console.Write("Make a selection: ");
                switch (Console.ReadLine().ToLower()[0])
                {
                    case 'a':
                        AddBadgeMenu();
                        break;
                    case 'v':
                        ShowAllBadgesMenu();
                        break;
                    case 'e':
                        EditBadgeMenu();
                        break;
                    case 'x':
                        running = false;
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("Unrecognised command.");
                        break;
                }
            }

            Console.ReadLine();
        }
        public void ShowAllBadgesMenu()
        {
            Console.WriteLine("\nAll badges: \nBadge # \t Door Access");
            Dictionary<int, Badge> badges = badgeRepo.GetBadges();
            foreach(var r in badges)
            {
                string assembled = "";
                foreach(var t in r.Value.Doors)
                {
                    assembled += t + " ";
                }
                Console.Write(r.Value.BadgeID + "\t\t" + assembled + "\n");
            }
        }
        public void AddBadgeMenu()
        {
            bool valid = false;
            int id = -1;
            Console.WriteLine("\nAdding a new badge: \n");
            Console.Write("Please enter the badge id: ");
            while (!valid)
            {
                valid = int.TryParse(Console.ReadLine(), out id);
                if (!valid)
                {
                    Console.Write("Please enter a numerical value: ");
                }
            }
            valid = false;
            badgeRepo.AddBadge(new Badge(id, new List<string>()));

            Console.Write("Please enter a door this badge can access: ");
            while (!valid)
            {
                string resp = Console.ReadLine();
                if (resp.ToLower() == "done")
                {
                    valid = true;
                }
                else
                {
                    badgeRepo.EditBadge(id, false, resp);
                    Console.Write("Please enter another door this badge can access, or type 'done': ");
                }
            }
        }
        public void EditBadgeMenu()
        {
            Console.WriteLine("\nEdit a badge: \n");
            Console.Write("Enter a badge id to edit: ");
            bool valid = false;
            int id = -1;
            while (!valid)
            {
                valid = int.TryParse(Console.ReadLine(), out id);
                if (!valid)
                {
                    Console.Write("Please enter a numerical value: ");
                }
            }
            Badge working = badgeRepo.GetBadges()[id];
            bool editing = true;

            while (editing)
            {
                Console.Write("Would you like to add or remove a door (a/r)? 'x' to exit: ");
                switch (Console.ReadLine().ToLower()[0])
                {
                    case 'a':
                        Console.Write("Enter a door to add: ");
                        badgeRepo.EditBadge(working.BadgeID, false, Console.ReadLine());
                        break;
                    case 'r':
                        Console.Write("Enter a door to remove: ");
                        badgeRepo.EditBadge(working.BadgeID, true, Console.ReadLine());
                        break;
                    case 'x':
                        editing = false;
                        break;
                    default:
                        Console.Write("Unrecognised command, please use 'a', 'r', 'x': ");
                        break;
                }
            }
        }
    }
}