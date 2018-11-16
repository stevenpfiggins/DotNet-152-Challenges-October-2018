using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    class GreetRepository
    {
        List<Customer> _customers = new List<Customer>();

        public void AddCustomerToList(Customer customer)
        {
            _customers.Add(customer);
        }

        public List<Customer> GetCustomerList()
        {
            return _customers;
        }

        public string SendCorrectEmailType(Customer customer)
        {
            string emailType = "";
            switch (customer.CustomerType)
            {
                case CustomerType.Potential:
                    emailType = "We currently have the lowest rates on Helicopter Insurance";
                    break;
                case CustomerType.Current:
                    emailType = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case CustomerType.Past:
                    emailType = "It's been a long time since we've heard from you. We want you back.";
                    break;
            }
            return emailType;
        }

        public void SortRecipientList()
        {
            List<Customer> something = GetCustomerList().OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
            _customers = something;
        }
    }
}
