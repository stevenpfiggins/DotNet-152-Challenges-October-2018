using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    class SmartInsuranceRepository
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
            List<Driver> driverPoints = ShowDriverList().OrderBy(d => d.TotalPoints).ThenBy(d => d.DriverName).ToList();
            _drivers = driverPoints;
        }

        public decimal CalculatePremium()
        {
            decimal basePremium = 80.00m;
            decimal totalPremium = 0.00m;
            foreach (var driver in _drivers)
            {
                if (driver.TypeOfDriver == DriverType.Good)
                {
                    totalPremium = basePremium - 25.00m;
                }
                else if (driver.TypeOfDriver == DriverType.Normal)
                {
                    totalPremium = basePremium;
                }
                else if (driver.TypeOfDriver == DriverType.Bad)
                {
                    totalPremium = basePremium + 25.00m;
                }
            }
            return totalPremium;
        }
    }
}
