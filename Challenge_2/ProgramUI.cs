using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    class ProgramUI
    {
        ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool menuRunning = true;
            while (menuRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Insurance Claim Portal.\n" +
                    "Please select an option.\n\t" +
                    "1. See All Claims\n\t" +
                    "2. Take Care of Next Claim\n\t" +
                    "3. Enter New Claim\n\t" +
                    "4. Exit");
                int menuAnswer = int.Parse(Console.ReadLine());
                switch (menuAnswer)
                {
                    case 1:
                        if (_claimRepo.SeeClaimQueue().Count < 1)
                        {
                            NoClaimsInQueuePrompt();
                        }
                        else
                        {
                            SeeClaims();
                        }
                        break;
                    case 2:
                        if (_claimRepo.SeeClaimQueue().Count < 1)
                        {
                            NoClaimsInQueuePrompt();
                        }
                        else
                        {
                            ResolveClaim();
                        }
                        break;
                    case 3:
                        EnterClaim();
                        break;
                    case 4:
                        menuRunning = false;
                        break;
                    default:
                        Console.WriteLine($"{menuAnswer} is not a valid input. Please select again.");
                        break;
                }

            }
        }

        private void SeeClaims()
        {
            Console.Clear();
            Console.WriteLine("{0,-12} {1,-10} {2,-25} {3,-12} {4,-20} {5,-16} {6,-10}\n", "ClaimID", "ClaimType", "Description", "ClaimAmount", "DateOfIncident", "DateOfClaim", "IsValid");
            foreach (Claim claim in _claimRepo.SeeClaimQueue())
            {
                Console.WriteLine("{0,-12} {1,-10} {2,-25} {3,-12} {4,-20} {5,-16} {6,-10}", $"{claim.ClaimID}", $"{claim.ClaimType}", $"{claim.Description}", $"${claim.ClaimAmount}", $"{claim.DateOfIncident.ToShortDateString()}", $"{claim.DateOfClaim.ToShortDateString()}", $"{claim.IsValid}");
            }
            Console.WriteLine("\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void ResolveClaim()
        {
            //Console.Clear();
            Console.WriteLine("Here are the details for the next claim that needs to be handled.\n" +
                "\n" +
                $"ClaimID: {_claimRepo.SeeClaimQueue().Peek().ClaimID}\n" +
                $"ClaimType: {_claimRepo.SeeClaimQueue().Peek().ClaimType}\n" +
                $"Description: {_claimRepo.SeeClaimQueue().Peek().Description}\n" +
                $"Amount: ${_claimRepo.SeeClaimQueue().Peek().ClaimAmount}\n" +
                $"DateOfIncident: {_claimRepo.SeeClaimQueue().Peek().DateOfIncident}\n" +
                $"DateOfClaim: {_claimRepo.SeeClaimQueue().Peek().DateOfClaim}\n" +
                $"IsValid: {_claimRepo.SeeClaimQueue().Peek().IsValid}\n" +
                $"\n" +
                $"Would you like to resolve this claim now? (y/n)");
            string claimResolveAnswer = Console.ReadLine().ToLower();
            switch (claimResolveAnswer)
            {
                case "y":
                    Console.WriteLine("This claim has been resolved.", _claimRepo.SeeClaimQueue().Dequeue());
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "n":
                    break;
                default:
                    break;
            }
        }

        private void EnterClaim()
        {
            Claim newClaim = new Claim();
            Console.Clear();
            Console.WriteLine("Please answer the following prompts to enter a new claim.\n" +
                "What is the ID number for the claim?");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the claim type?");
            newClaim.ClaimType = Console.ReadLine();
            Console.WriteLine("Please provide a description of the claim.");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine("What is the amount of damages?");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("What was the date of the incident? (MM/DD/YYYY)");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("What was the date of the claim? (MM/DD/YYYY)");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            int days = (newClaim.DateOfClaim - newClaim.DateOfIncident).Days;
            if (days >= 0 && days <= 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }
            _claimRepo.AddClaimToQueue(newClaim);
        }

        private void NoClaimsInQueuePrompt()
        {
            Console.Clear();
            Console.WriteLine("There are no claims to see. Please enter a new claim.\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }
    }
}
