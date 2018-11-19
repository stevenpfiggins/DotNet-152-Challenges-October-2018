using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    class ProgramUI
    {
        SmartInsuranceRepository _smartInsuranceRepo = new SmartInsuranceRepository();
        public void RunMenu()
        {
            bool menuRunning = true;
            while (menuRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Smart Insurance Portal.\n" +
                    "Please select an option below.\n\t" +
                    "1. Add Driver to Driver Info List\n\t" +
                    "2. See Driver Info List\n\t" +
                    "3. Update Driver Information\n\t" +
                    "4. Remove Driver from Info List\n\t" +
                    "5. Exit");
                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        AddNewDriver();
                        break;
                    case "2":
                        if (_smartInsuranceRepo.ShowDriverList().Count < 1)
                        {
                            NoDriversInListPrompt();
                        }
                        else
                        {
                            Console.Clear();
                            SeeAllDrivers();
                        }
                        break;
                    case "3":
                        if (_smartInsuranceRepo.ShowDriverList().Count < 1)
                        {
                            NoDriversInListPrompt();
                        }
                        else
                        {
                            UpdateDriverInfo();
                        }
                        break;
                    case "4":
                        if (_smartInsuranceRepo.ShowDriverList().Count < 1)
                        {
                            NoDriversInListPrompt();
                        }
                        else
                        {
                            RemoveDriver();
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

        private void AddNewDriver()
        {
            Console.Clear();
            Driver newDriver = new Driver();
            Console.WriteLine("To enter a new driver and calculate their premium, please enter the information below.\n" +
                "What is the first name of the driver?");
            newDriver.DriverFirstName = Console.ReadLine();
            Console.WriteLine("What is the last name of the driver?");
            newDriver.DriverLastName = Console.ReadLine();
            newDriver.TimesSped = 0;
            newDriver.TimesSwerved = 0;
            newDriver.TimesRolledThroughStop = 0;
            newDriver.TimesFollowedTooClose = 0;
            newDriver.TotalPoints = newDriver.TimesSped + newDriver.TimesSwerved + newDriver.TimesRolledThroughStop + newDriver.TimesFollowedTooClose;
            _smartInsuranceRepo.AddDriverToList(newDriver);
        }

        private void SeeAllDrivers()
        {
            Console.WriteLine($"\t{"FirstName",-15} {"LastName",-15} {"TotalPoints",-15} {"DriverType",-15} {"TotalPremium"}\n");
            int i = 0;
            decimal basePremium = 80.00m;
            foreach (var driver in _smartInsuranceRepo.ShowDriverList())
            {
                i++;
                if (driver.TotalPoints >= 0 && driver.TotalPoints <= 20)
                {
                    driver.TypeOfDriver = DriverType.Good;
                }
                else if (driver.TotalPoints > 20 && driver.TotalPoints <= 80)
                {
                    driver.TypeOfDriver = DriverType.Normal;
                }
                else if (driver.TotalPoints > 80)
                {
                    driver.TypeOfDriver = DriverType.Bad;
                }
                if (driver.TypeOfDriver == DriverType.Good)
                {
                    driver.TotalPremium = basePremium - 25.00m;
                }
                else if (driver.TypeOfDriver == DriverType.Normal)
                {
                    driver.TotalPremium = basePremium;
                }
                else if (driver.TypeOfDriver == DriverType.Bad)
                {
                    driver.TotalPremium = basePremium + 25.00m;
                }
                //_smartInsuranceRepo.SortDriverList();
                Console.WriteLine($"{i}.\t" +
                    $"{driver.DriverFirstName,-15} {driver.DriverLastName,-15} {driver.TotalPoints,-15} {driver.TypeOfDriver,-15} ${driver.TotalPremium}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void UpdateDriverInfo()
        {
            Console.Clear();
            SeeAllDrivers();
            Console.WriteLine("Which driver would you like to update?");
            int driverSelectInt = int.Parse(Console.ReadLine());
            var driverSelectActual = _smartInsuranceRepo.ShowDriverList()[driverSelectInt - 1];
            Console.WriteLine("What point type would you like to update?\n\t" +
                "1. Speeding\n\t" +
                "2. Swerving\n\t" +
                "3. Rolling Through Stop Sign\n\t" +
                "4. Following Too Closely");
            string updateSelect = Console.ReadLine();
            switch (updateSelect)
            {
                case "1":
                    Console.WriteLine("How many points has the driver accrued?");
                    int spedAccrual = int.Parse(Console.ReadLine());
                    driverSelectActual.TimesSped = driverSelectActual.TimesSped + spedAccrual;
                    break;
                case "2":
                    Console.WriteLine("How many points has the driver accrued?");
                    int swerveAccrual = int.Parse(Console.ReadLine());
                    driverSelectActual.TimesSwerved = driverSelectActual.TimesSwerved + swerveAccrual;
                    break;
                case "3":
                    Console.WriteLine("How many points has the driver accrued?");
                    int rollingAccrual = int.Parse(Console.ReadLine());
                    driverSelectActual.TimesRolledThroughStop = driverSelectActual.TimesRolledThroughStop + rollingAccrual;
                    break;
                case "4":
                    Console.WriteLine("How many points has the driver accrued?");
                    int followingAccrual = int.Parse(Console.ReadLine());
                    driverSelectActual.TimesFollowedTooClose = driverSelectActual.TimesFollowedTooClose + followingAccrual;
                    break;
            }
            driverSelectActual.TotalPoints = driverSelectActual.TimesSped + driverSelectActual.TimesSwerved + driverSelectActual.TimesRolledThroughStop + driverSelectActual.TimesFollowedTooClose;
            Console.WriteLine("Here is the updated driver list.");
            SeeAllDrivers();

        }

        private void RemoveDriver()
        {
            Console.Clear();
            SeeAllDrivers();
            Console.WriteLine("Which recipient would you like to remove?");
            int whichRecipientRemove = int.Parse(Console.ReadLine());
            _smartInsuranceRepo.ShowDriverList().RemoveAt(whichRecipientRemove - 1);
            Console.Clear();
            Console.WriteLine("This is the updated recipients list.");
            SeeAllDrivers();
        }

        private void NoDriversInListPrompt()
        {
            Console.Clear();
            Console.WriteLine("There are no drivers to see. Please enter a new driver.\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }
    }
}
