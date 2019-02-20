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

        public void Run()
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 45;

            AddClaimMenu();
            Console.ReadLine();
        }

        public void AddClaimMenu()
        {
            bool valid = false;
            int id;
            TypeOfClaim type;
            string desc;
            double amt;
            string accDate;
            string clmDate;

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
                switch()
            }
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