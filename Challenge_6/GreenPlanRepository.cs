using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public class GreenPlanRepository
    {
        List<Car> _cars = new List<Car>();

        public void AddCarToFullList(Car car)
        {
            _cars.Add(car);
        }

        public List<Car> SeeFullListOfCars()
        {
            return _cars;
        }

        public void SortFullCarList()
        {
            List<Car> cars = SeeFullListOfCars().OrderBy(c => c.CarMake).ThenBy(c => c.CarModel).ToList();
            _cars = cars;
        }
    }
}
