using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public enum CarType { Electric, Hybrid, Gas }
    public class Car
    {
        public CarType TypeOfCar { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public float MilesPerGallon { get; set; }
        public float MilesPerKiloWattHour { get; set; }

        public Car(CarType typeOfCar, string carMake, string carModel, float milesPerGallon, float milesPerKiloWattHour)
        {
            TypeOfCar = typeOfCar;
            CarMake = carMake;
            CarModel = carModel;
            MilesPerGallon = milesPerGallon;
            MilesPerKiloWattHour = milesPerKiloWattHour;
        }

        public Car()
        {

        }
    }
}
