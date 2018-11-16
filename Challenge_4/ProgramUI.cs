using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class ProgramUI
    {
        BadgeRepository _badgeRepo = new BadgeRepository();

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
                Console.WriteLine("Welcome to the Komodo Badge Portal\n" +
                    "Please select an option below.\n\t" +
                    "1. Create New Badge\n\t" +
                    "2. Update Door Access\n\t" +
                    "3. Remove Door Access\n\t" +
                    "4. Show Badge List\n\t" +
                    "5. Exit");
                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        if (_badgeRepo.ShowDictionaryContents().Count == 0)
                        {
                            NoBadgesInDictionaryPrompt();
                        }
                        else
                        {
                            UpdateDoorAccess();
                        }
                        break;
                    case "3":
                        if (_badgeRepo.ShowDictionaryContents().Count == 0)
                        {
                            NoBadgesInDictionaryPrompt();
                        }
                        else
                        {
                            RemoveDoorAccess();
                        }
                        break;
                    case "4":
                        if (_badgeRepo.ShowDictionaryContents().Count == 0)
                        {
                            NoBadgesInDictionaryPrompt();
                        }
                        else
                        {
                            ShowDictionary();
                        }
                        break;
                    case "5":
                        menuRunning = false;
                        break;
                    default:
                        Console.WriteLine($"{menuSelection} is not a valid input. Please select again.\n" +
                            $"Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CreateBadge()
        {
            Badge newBadge = new Badge();
            Console.Clear();
            Console.WriteLine("To create a badge, answer the prompts below.\n" +
                "What is the badge ID?");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            newBadge.DoorAccess = AddDoorAccessDuringBadgeCreation();
            _badgeRepo.AddBadgeToDictionary(newBadge);
        }

        private void UpdateDoorAccess()
        {
            Console.Clear();
            ShowDictionary();
            Console.WriteLine("What badge would you like to update?");
            int key = int.Parse(Console.ReadLine());
            _badgeRepo.UpdateDoorAccess(key, AddDoorAccessDuringBadgeCreation());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void RemoveDoorAccess()
        {
            Console.Clear();
            ShowDictionary();
            Console.WriteLine("What badge would you like to remove door access to?");
            int key = int.Parse(Console.ReadLine());
            _badgeRepo.RemoveDoorAccess(key);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ShowDictionary()
        {
            Console.Clear();
            Console.WriteLine($"{"Badge",-8} {"DoorAccess"}\n");
            foreach (KeyValuePair<int, List<string>> kvp in _badgeRepo.ShowDictionaryContents())
            {
                Console.WriteLine($"{kvp.Key,-8} {PrintOutDoorAccessList(kvp.Value)}");
            }
            Console.WriteLine("\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private List<string> AddDoorAccessDuringBadgeCreation()
        {
            var doorsAccess = new List<string>();
            Console.Clear();
            Console.WriteLine("Would you like to add a new door access to this badge? (yes/no)");
            string answer = Console.ReadLine().ToLower();
            while (answer.Contains("y"))
            {
                Console.WriteLine("What door would you like to add access to?");
                string doorAccess = Console.ReadLine();
                doorsAccess.Add(doorAccess);
                Console.WriteLine("Would you like to add access to another door? (yes/no)");
                answer = Console.ReadLine();
            }
            return doorsAccess;
        }

        private string PrintOutDoorAccessList(List<string> doors)
        {
            string printedDoors = "";
            foreach (string door in doors)
            {
                printedDoors = printedDoors + ", " + door;
            }
            return printedDoors;
        }

        private void NoBadgesInDictionaryPrompt()
        {
            Console.Clear();
            Console.WriteLine("There are no badges to see. Please enter a new badge.\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }
    }
}
