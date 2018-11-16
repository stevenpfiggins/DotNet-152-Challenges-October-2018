using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class Outing
    {
        public string OutingType { get; set; }
        public int Attendance { get; set; }
        public DateTime OutingDate { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; set; }

        public Outing(string outingType, int attendance, DateTime outingDate, decimal costPerPerson, decimal totalCost)
        {
            OutingType = outingType;
            Attendance = attendance;
            OutingDate = outingDate;
            CostPerPerson = costPerPerson;
            TotalCost = totalCost;
        }

        public Outing()
        {

        }
    }
}
