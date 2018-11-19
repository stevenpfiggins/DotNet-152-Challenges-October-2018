using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class ProgramUI
    {
        OutingRepository _outingRepo = new OutingRepository();

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
                Console.WriteLine("Welcome to the Komodo Outing Portal.\n" +
                    "Please select an option below.\n\t" +
                    "1. Display List of Outings\n\t" +
                    "2. Cost of Outings\n\t" +
                    "3. Add New Outing\n\t" +
                    "4. Exit");
                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        if (_outingRepo.GetOutingList().Count == 0)
                        {
                            NoOutingsInListPrompt();
                        }
                        else
                        {
                            DisplayOutings();
                        }
                        break;
                    case "2":
                        if (_outingRepo.GetOutingList().Count == 0)
                        {
                            NoOutingsInListPrompt();
                        }
                        else
                        {
                            DisplayCostOfOutings();
                        }
                        break;
                    case "3":
                        AddNewOuting();
                        break;
                    case "4":
                        menuRunning = false;
                        break;
                    default:
                        Console.WriteLine($"{menuSelection} is not a valid input.\n" +
                            $"Press any key to select again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddNewOuting()
        {
            Outing newOuting = new Outing();
            Console.Clear();
            Console.WriteLine("To add a new outing, please answer the following prompts.\n" +
                "What was the type of outing?");
            newOuting.OutingType = Console.ReadLine().ToLower();
            Console.WriteLine("How many people attended the outing?");
            newOuting.Attendance = int.Parse(Console.ReadLine());
            Console.WriteLine("What was the date of the outing? (MM/DD/YYYY)");
            newOuting.OutingDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("What was the total cost for the outing?");
            newOuting.TotalCost = decimal.Parse(Console.ReadLine());
            newOuting.CostPerPerson = newOuting.TotalCost / newOuting.Attendance;
            _outingRepo.AddOutingToList(newOuting);
        }

        private void DisplayCostOfOutings()
        {
            Console.Clear();
            var totalForDisplay = _outingRepo.GetTotalCostForAllOutings();
            var totalForGolfDisplay = _outingRepo.GetTotalCostForGolfOutings();
            var totalForBowlingDisplay = _outingRepo.GetTotalCostForBowlingOutings();
            var totalForAmusementParkDisplay = _outingRepo.GetTotalCostForAmusementParkOutings();
            var totalForConcertDisplay = _outingRepo.GetTotalCostForConcertOutings();
            Console.WriteLine($"Here is the total cost of all outings:\n" +
                $"${totalForDisplay:N2}\n\n" +
                $"Here is the total cost for golf outings:\n" +
                $"${totalForGolfDisplay:N2}\n\n" +
                $"Here is the total cost for bowling outings\n" +
                $"${totalForBowlingDisplay:N2}\n\n" +
                $"Here is the total cost for amusement park outings\n" +
                $"${totalForAmusementParkDisplay:N2}\n\n" +
                $"Here is the total cost for concert outings\n" +
                $"${totalForConcertDisplay:N2}\n\n" +
                $"Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplayOutings()
        {
            Console.Clear();
            Console.WriteLine($"{"OutingType",-15} {"Attendance",-15} {"DateOfOuting",-15} {"Cost/Person",-15} {"TotalCost",-15}\n");
            foreach (Outing outing in _outingRepo.GetOutingList())
            {
                Console.WriteLine($"{outing.OutingType,-15} {outing.Attendance,-15} {outing.OutingDate.ToShortDateString(),-15} ${outing.CostPerPerson,-15:N2} ${outing.TotalCost,-15:N2}");
            }
            Console.WriteLine("\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void NoOutingsInListPrompt()
        {
            Console.Clear();
            Console.WriteLine("There are no outings to see. Please enter a new outing.\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }
    }
}
