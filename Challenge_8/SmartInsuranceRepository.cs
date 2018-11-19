using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    public class SmartInsuranceRepository
    {
        List<Driver> _drivers = new List<Driver>();

        public void AddDriverToList(Driver driver)
        {
            _drivers.Add(driver);
        }

        public List<Driver> ShowDriverList()
        {
            return _drivers;
        }

        public void SortDriverList()
        {
            List<Driver> driverPoints = ShowDriverList().OrderBy(d => d.TotalPoints).ThenBy(d => d.DriverLastName).ThenBy(d => d.DriverFirstName).ToList();
            _drivers = driverPoints;
        }
    }
}
