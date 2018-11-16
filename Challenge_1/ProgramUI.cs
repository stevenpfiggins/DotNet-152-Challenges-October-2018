using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Cafe! Please select an option: \n\t" +
                    "1. Add New Menu Item\n\t" +
                    "2. See Menu\n\t" +
                    "3. Remove Menu Item\n\t" +
                    "4. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddMenuItem();
                        break;
                    case 2:
                        PrintMenu();
                        break;
                    case 3:
                        RemoveMenuItem();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine($"{input} is not a valid input. Press any key to select again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddMenuItem()
        {
            Console.Clear();
            Menu newMenuItem = new Menu();
            Console.WriteLine("What number should this be on the menu?");
            newMenuItem.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the name of the menu item?");
            newMenuItem.MealName = Console.ReadLine();
            Console.WriteLine("What is the description of the menu item?");
            newMenuItem.MealDescription = Console.ReadLine();
            newMenuItem.Ingredients = AddIngredient();
            Console.WriteLine("What is the price of the menu item? (no $ sign)");
            newMenuItem.MealPrice = decimal.Parse(Console.ReadLine());
            _menuRepo.AddMenuItemToList(newMenuItem);
        }

        private List<string> AddIngredient()
        {
            var ingredients = new List<string>();

            Console.WriteLine("Would you like to add an ingredient to the menu item? (yes/no)");
            string answer = Console.ReadLine().ToLower();
            while (answer.Contains("y"))
            {
                Console.WriteLine("What is the ingredient?");
                string ingredient = Console.ReadLine();
                ingredients.Add(ingredient);
                Console.WriteLine("Would you like to add another ingredient? (yes/no)");
                answer = Console.ReadLine();
            }
            return ingredients;
        }

        private void PrintMenu()
        {
            Console.Clear();
            int i = 0;
            foreach (Menu menuItem in _menuRepo.GetMenuList())
            {
                i++;
                Console.WriteLine(i + ".\t" + $"Meal Number: #{menuItem.MealNumber}\n\t" +
                    $"Meal Name: {menuItem.MealName}\n\t" +
                    $"Meal Description: {menuItem.MealDescription}\n\t" +
                    $"Meal Ingredients: {PrintOutIngredients(menuItem.Ingredients)}\n\t" +
                    $"Meal Price: ${menuItem.MealPrice}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void RemoveMenuItem()
        {
            Console.Clear();
            PrintMenu();
            Console.WriteLine("Please select a menu item to remove.");
            int menuItemRemove = int.Parse(Console.ReadLine());
            _menuRepo.GetMenuList().RemoveAt(menuItemRemove - 1);
            Console.Clear();
            Console.WriteLine("Here is the updated menu");
            PrintMenu();
        }

        private string PrintOutIngredients(List<string> ingredients)
        {
            string printedIngredients = "";
            foreach (string ingredient in ingredients)
            {
                printedIngredients = printedIngredients + ", " + ingredient;
            }
            return printedIngredients;
        }

    }
}
