using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public class Booth
    {
        public string BoothName { get; set; }
        public int TicketsTaken { get; set; }
        public decimal BoothTotalCost { get; set; }
    }

    class Burger : Booth
    {
        public decimal HamburgerCost { get; set; }
        public decimal VeggieBurgerCost { get; set; }
        public decimal HotDogCost { get; set; }
        public decimal BurgerMiscCost { get; set; }
    }

    class Treat : Booth
    {
        public decimal PopcornCost { get; set; }
        public decimal IceCreamCost { get; set; }
        public decimal TreatMiscCost { get; set; }
    }
}
