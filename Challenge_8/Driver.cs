using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    public enum DriverType
    {
        Good, Normal, Bad
    }
    class Driver
    {
        public DriverType TypeOfDriver { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
        public int TimesSped { get; set; }
        public int TimesSwerved { get; set; }
        public int TimesRolledThroughStop { get; set; }
        public int TimesFollowedTooClose { get; set; }
        public int TotalPoints { get; set; }
        public decimal TotalPremium { get; set; }

        public Driver(DriverType typeOfDriver, string driverFirstName, string driverLastName, int timesSped, int timesSwerved, int timesRolled, int timesFollowedTooClose, int totalPoints, decimal totalPremium)
        {
            TypeOfDriver = typeOfDriver;
            DriverFirstName = driverFirstName;
            DriverLastName = driverLastName;
            TimesSped = timesSped;
            TimesSwerved = timesSwerved;
            TimesRolledThroughStop = timesRolled;
            TimesFollowedTooClose = timesFollowedTooClose;
            TotalPoints = totalPoints;
            TotalPremium = totalPremium;
        }

        public Driver()
        {

        }
    }
}
