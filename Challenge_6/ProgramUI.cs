using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public class ProgramUI
    {
        GreenPlanRepository _greenPlanRepo = new GreenPlanRepository();

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
                Console.WriteLine("Welcome to the Komodo Green Plan Portal.\n" +
                    "Please select an option below.\n\t" +
                    "1. Add Vehicle to Informational List\n\t" +
                    "2. See Full Informational List\n\t" +
                    "3. See Informational List By Vehicle Type\n\t" +
                    "4. Update Vehicle Information\n\t" +
                    "5. Remove Vehicle from Informational List\n\t" +
                    "6. Exit");
                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        AddNewVehicle();
                        break;
                    case "2":
                        if (_greenPlanRepo.SeeFullListOfCars().Count < 1)
                        {
                            NoVehiclesInListPrompt();
                        }
                        else
                        {
                            SeeAllVehicles();
                        }
                        break;
                    case "3":
                        if (_greenPlanRepo.SeeFullListOfCars().Count < 1)
                        {
                            NoVehiclesInListPrompt();
                        }
                        else
                        {
                            SeeSpecificVehicleType();
                        }
                        break;
                    case "4":
                        if (_greenPlanRepo.SeeFullListOfCars().Count < 1)
                        {
                            NoVehiclesInListPrompt();
                        }
                        else
                        {
                            UpdateVehicleInfo();
                        }
                        break;
                    case "5":
                        if (_greenPlanRepo.SeeFullListOfCars().Count < 1)
                        {
                            NoVehiclesInListPrompt();
                        }
                        else
                        {
                            RemoveVehicle();
                        }
                        break;
                    case "6":
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

        private void AddNewVehicle()
        {
            Console.Clear();
            Car car = new Car();
            Console.WriteLine("To add a vehicle to the informational list, please complete the following prompts.\n" +
                "What type of vehicle is it? (Electric/Hybrid/Gas)");
            string carType = Console.ReadLine().ToLower();
            switch (carType)
            {
                case "electric":
                    car.TypeOfCar = CarType.Electric;
                    break;
                case "hybrid":
                    car.TypeOfCar = CarType.Hybrid;
                    break;
                case "gas":
                    car.TypeOfCar = CarType.Gas;
                    break;
            }
            Console.WriteLine("What is the make of the vehicle?");
            car.CarMake = Console.ReadLine();
            Console.WriteLine("What is the model of the vehicle?");
            car.CarModel = Console.ReadLine();
            Console.WriteLine("What is the miles per gallon of this vehicle?");
            car.MilesPerGallon = float.Parse(Console.ReadLine());
            Console.WriteLine("What is the miles per kilowatt hour of this vehicle?");
            car.MilesPerKiloWattHour = float.Parse(Console.ReadLine());
            _greenPlanRepo.AddCarToFullList(car);
        }

        private void SeeAllVehicles()
        {
            _greenPlanRepo.SortFullCarList();
            Console.WriteLine("\t" + $"{"CarType",-15} {"CarMake",-15} {"CarModel",-15} {"MilesPerGallon",-15} {"MilesPerKilowattHour"}");
            int i = 0;
            foreach (Car car in _greenPlanRepo.SeeFullListOfCars())
            {
                i++;
                Console.WriteLine(i + ".\t" + $"{car.TypeOfCar,-15} {car.CarMake,-15} {car.CarModel,-15} {car.MilesPerGallon,-15} {car.MilesPerKiloWattHour}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void SeeSpecificVehicleType()
        {
            Console.Clear();
            Console.WriteLine("What type of vehicle would you like to see? (electric/hybrid/gas)");
            string typeOfVehicleAnswer = Console.ReadLine().ToLower();
            if (typeOfVehicleAnswer == "electric")
            {
                List<Car> electricCars = _greenPlanRepo.SeeFullListOfCars().Where(c => c.TypeOfCar == CarType.Electric).ToList();
                electricCars.Sort((x, y) => string.Compare(x.CarMake, y.CarMake));
                Console.WriteLine("\t" + $"{"CarType",-15} {"CarMake",-15} {"CarModel",-15} {"MilesPerGallon",-15} {"MilesPerKilowattHour"}");
                int i = 0;
                foreach (Car car in electricCars)
                {
                    i++;
                    Console.WriteLine(i + ".\t" + $"{car.TypeOfCar,-15} {car.CarMake,-15} {car.CarModel,-15} {car.MilesPerGallon,-15} {car.MilesPerKiloWattHour}");
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else if (typeOfVehicleAnswer == "hybrid")
            {
                List<Car> hybridCars = _greenPlanRepo.SeeFullListOfCars().Where(c => c.TypeOfCar == CarType.Hybrid).ToList();
                hybridCars.Sort((x, y) => string.Compare(x.CarMake, y.CarMake));
                Console.WriteLine("\t" + $"{"CarType",-15} {"CarMake",-15} {"CarModel",-15} {"MilesPerGallon",-15} {"MilesPerKilowattHour"}");
                int i = 0;
                foreach (Car car in hybridCars)
                {
                    i++;
                    Console.WriteLine(i + ".\t" + $"{car.TypeOfCar,-15} {car.CarMake,-15} {car.CarModel,-15} {car.MilesPerGallon,-15} {car.MilesPerKiloWattHour}");
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else if (typeOfVehicleAnswer == "gas")
            {
                List<Car> gasCars = _greenPlanRepo.SeeFullListOfCars().Where(c => c.TypeOfCar == CarType.Gas).ToList();
                gasCars.Sort((x, y) => string.Compare(x.CarMake, y.CarMake));
                Console.WriteLine("\t" + $"{"CarType",-15} {"CarMake",-15} {"CarModel",-15} {"MilesPerGallon",-15} {"MilesPerKilowattHour"}");
                int i = 0;
                foreach (Car car in gasCars)
                {
                    i++;
                    Console.WriteLine(i + ".\t" + $"{car.TypeOfCar,-15} {car.CarMake,-15} {car.CarModel,-15} {car.MilesPerGallon,-15} {car.MilesPerKiloWattHour}");
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void UpdateVehicleInfo()
        {
            Console.Clear();
            SeeAllVehicles();
            Console.WriteLine("Which vehicle would you like to update?");
            int whichVehicleUpdate = int.Parse(Console.ReadLine());
            var actualVehicleUpdate = _greenPlanRepo.SeeFullListOfCars()[whichVehicleUpdate - 1];
            Console.WriteLine("What vehicle property would you like to update. (MilesPerGallon/MilesPerKilowattHour)");
            string vehicleUpdate = Console.ReadLine().ToLower();
            switch (vehicleUpdate)
            {
                case "milespergallon":
                    Console.WriteLine("What is the MilesPerGallon of the vehicle?");
                    float gallon = float.Parse(Console.ReadLine());
                    actualVehicleUpdate.MilesPerGallon = gallon;
                    break;
                case "milesperkilowatthour":
                    Console.WriteLine("What is the MilesPerKiloWattHour of the vehicle?");
                    float kilowatt = float.Parse(Console.ReadLine());
                    actualVehicleUpdate.MilesPerKiloWattHour = kilowatt;
                    break;
            }
            Console.Clear();
            Console.WriteLine("Here is the updated vehicle list.");
            SeeAllVehicles();
        }

        private void RemoveVehicle()
        {
            Console.Clear();
            SeeAllVehicles();
            Console.WriteLine("Which vehicle would you like to remove?");
            int whichVehicleRemove = int.Parse(Console.ReadLine());
            _greenPlanRepo.SeeFullListOfCars().RemoveAt(whichVehicleRemove - 1);
            Console.Clear();
            Console.WriteLine("This is the updated vehicle list.");
            SeeAllVehicles();
        }

        private void NoVehiclesInListPrompt()
        {
            Console.Clear();
            Console.WriteLine("There are no vehicles to see. Please enter a new vehicles.\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }
    }
}
