using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class ProgramUI
    {
        GreetRepository _greetRepo = new GreetRepository();

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
                Console.WriteLine("Welcome to the Komodo Email Everyone Portal.\n" +
                    "Please select an option below.\n\t" +
                    "1. Create New Email Recipient\n\t" +
                    "2. See All Email Recipients\n\t" +
                    "3. Update Email Recipients List\n\t" +
                    "4. Remove Email Recipients\n\t" +
                    "5. Exit");
                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        CreateNewEmailRecipient();
                        break;
                    case "2":
                        if (_greetRepo.GetCustomerList().Count == 0)
                        {
                            NoCustomersInListPrompt();
                        }
                        else
                        {
                            Console.Clear();
                            SeeAllEmailRecipients();
                        }
                        break;
                    case "3":
                        if (_greetRepo.GetCustomerList().Count == 0)
                        {
                            NoCustomersInListPrompt();
                        }
                        else
                        {
                            UpdateEmailRecipient();
                        }
                        break;
                    case "4":
                        if (_greetRepo.GetCustomerList().Count == 0)
                        {
                            NoCustomersInListPrompt();
                        }
                        else
                        {
                            RemoveEmailRecipients();
                        }
                        break;
                    case "5":
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

        private void RemoveEmailRecipients()
        {
            Console.Clear();
            SeeAllEmailRecipients();
            Console.WriteLine("Which recipient would you like to remove?");
            int whichRecipientRemove = int.Parse(Console.ReadLine());
            _greetRepo.GetCustomerList().RemoveAt(whichRecipientRemove - 1);
            Console.Clear();
            Console.WriteLine("This is the updated recipients list.");
            SeeAllEmailRecipients();
        }

        private void UpdateEmailRecipient()
        {
            Console.Clear();
            SeeAllEmailRecipients();
            Console.WriteLine("Which recipient would you like to update?");
            int whichRecipientUpdate = int.Parse(Console.ReadLine());
            var actualRecipientUpdate = _greetRepo.GetCustomerList()[whichRecipientUpdate - 1];
            Console.WriteLine("To which recipient type are they being updated? (current/past)");
            string recipientTypeUpdate = Console.ReadLine().ToLower();
            switch (recipientTypeUpdate)
            {
                case "current":
                    actualRecipientUpdate.CustomerType = CustomerType.Current;
                    break;
                case "past":
                    actualRecipientUpdate.CustomerType = CustomerType.Past;
                    break;
            }
            Console.Clear();
            Console.WriteLine("Here is the updated recipients list.");
            SeeAllEmailRecipients();

        }

        private void SeeAllEmailRecipients()
        {
            _greetRepo.SortRecipientList();
            Console.WriteLine("\t" + $"{"FirstName",-15} {"LastName",-15} {"Type",-15} {"Email"}\n\n");
            int i = 0;
            foreach (Customer customer in _greetRepo.GetCustomerList())
            {
                i++;
                Console.WriteLine(i + ".\t" + $"{customer.FirstName,-15} {customer.LastName,-15} {customer.CustomerType,-15} {_greetRepo.SendCorrectEmailType(customer)}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void CreateNewEmailRecipient()
        {
            Customer customer = new Customer();
            Console.Clear();
            Console.WriteLine("To add an email recipient to the list, complete the following prompts.\n" +
                "What is the recipient's first name?");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("What is the recipient's last name?");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Is the recipient a current customer, potential customer, or past customer?");
            string recipientType = Console.ReadLine().ToLower();
            switch (recipientType)
            {
                case "current":
                    customer.CustomerType = CustomerType.Current;
                    break;
                case "potential":
                    customer.CustomerType = CustomerType.Potential;
                    break;
                case "past":
                    customer.CustomerType = CustomerType.Past;
                    break;
            }
            _greetRepo.AddCustomerToList(customer);
        }

        private void NoCustomersInListPrompt()
        {
            Console.Clear();
            Console.WriteLine("There are no customers to see. Please enter a new outing.\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }
    }
}
