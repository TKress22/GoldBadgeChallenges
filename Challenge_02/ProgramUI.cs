using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    class ProgramUI
    {
        ClaimRepository claimRepo = new ClaimRepository();
        bool running = true;

        public void Run()
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 45;

            Console.WriteLine("Komodo Claims App\n");

            while (running)
            {
                Console.Write("Enter 'a' to add a new claim, 'v' to view all claims, 'h' to handle the next claim or 'x' to exit: ");
                switch (Console.ReadLine().ToLower()[0])
                {
                    case 'a':
                        AddClaimMenu();
                        break;
                    case 'v':
                        ViewClaims();
                        break;
                    case 'h':
                        WorkClaimMenu();
                        break;
                    case 'x':
                        Console.WriteLine("Bye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Unrecognised command");
                        break;
                }
            }

            Console.ReadLine();
        }

        public void AddClaimMenu()
        {
            bool valid = false;

            int id = -1;
            TypeOfClaim type = TypeOfClaim.Car;
            string desc;
            double amt = 0;
            DateTime accDate = new DateTime();
            DateTime clmDate = new DateTime();
            Dictionary<string, int> test = new Dictionary<string, int>();

            Console.WriteLine("New claim:\n");

            Console.Write("Enter the claim id: ");
            while (!valid)
            {
                valid = int.TryParse(Console.ReadLine(), out id);
                if (!valid)
                {
                    Console.Write("Please enter a numerical value: ");
                }
            }
            valid = false;

            Console.Write("Enter the claim type: ");
            while (!valid)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "house":
                        type = TypeOfClaim.House;
                        valid = true;
                        break;
                    case "car":
                        type = TypeOfClaim.Car;
                        valid = true;
                        break;
                    case "theft":
                        type = TypeOfClaim.Theft;
                        valid = true;
                        break;
                    default:
                        Console.Write("Invalid type. Types are (House, Theft, Car): ");
                        break;
                }
            }
            valid = false;

            Console.Write("Enter a claim description: ");
            desc = Console.ReadLine();

            Console.Write("Enter the claim amount: ");
            while (!valid)
            {
                valid = double.TryParse(Console.ReadLine(), out amt);
                if (!valid)
                {
                    Console.Write("Please enter a numerical value: ");
                }
            }
            valid = false;

            Console.Write("Enter the accident date: ");
            while (!valid)
            {
                valid = DateTime.TryParse(Console.ReadLine(), out accDate);
                if (!valid)
                {
                    Console.Write("Please enter a valid date (mm/dd/yy): ");
                }
            }
            valid = false;

            Console.Write("Enter the claim date: ");
            while (!valid)
            {
                valid = DateTime.TryParse(Console.ReadLine(), out clmDate);
                if (!valid)
                {
                    Console.Write("Please enter a valid date (mm/dd/yy): ");
                }
            }
            valid = false;

            claimRepo.AddClaim(new Claim(id, type, desc, amt, accDate, clmDate));
        }

        public void WorkClaimMenu()
        {
            Console.WriteLine("Current claim: ");

            Claim clm = claimRepo.GetClaims().Peek();

            Console.WriteLine("Claim ID: " + clm.ClaimID);
            Console.WriteLine("Type: " + clm.ClaimType);
            Console.WriteLine("Description: " + clm.ClaimDescription);
            Console.WriteLine("Amount: " + clm.ClaimAmount);
            Console.WriteLine("DateOfIncident: " + claimRepo.ReturnPrettyDate(clm.AccidentDate));
            Console.WriteLine("DateOfClaim:  " + claimRepo.ReturnPrettyDate(clm.ClaimDate));
            Console.WriteLine("IsValid: " + clm.isValid());

            Console.Write("\nWould you like to deal with this claim now (y/n)?: ");
            bool valid = false;           
            while (!valid)
            {
                string resp = Console.ReadLine().ToLower();
                if (resp[0] == 'y')
                {
                    claimRepo.HandleClaim();
                    valid = true;
                }
                else if (resp[0] == 'n')
                {
                    valid = true;
                }
                else
                {
                    Console.Write("Invalid response, please enter 'y' or 'n': ");
                }
            }
        }

        public void ViewClaims()
        {
            Console.WriteLine("Current claims: \n");
            Console.WriteLine("Claim ID \t Type \t Description \t Amount \t DateOfAccident \t DateOfClaim \t isValid");
            Queue<Claim> clms = claimRepo.GetClaims();

            foreach(Claim r in clms)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6}", r.ClaimID, r.ClaimType, r.ClaimDescription, r.ClaimAmount, claimRepo.ReturnPrettyDate(r.AccidentDate), claimRepo.ReturnPrettyDate(r.ClaimDate), r.isValid());
            }
        }
    }
}