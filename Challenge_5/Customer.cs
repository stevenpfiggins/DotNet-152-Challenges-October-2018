using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public enum CustomerType { Current, Potential, Past }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType CustomerType { get; set; }

        public Customer(string firstName, string lastName, CustomerType customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
        }

        public Customer()
        {

        }
    }
}
