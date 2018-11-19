using System;
using System.Collections.Generic;
using Challenge_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_1_Tests
{
    [TestClass]
    public class Challenge_1_Tests
    {
        MenuRepository _menuRepo = new MenuRepository();
        Menu menu;
        List<Menu> list;
        List<string> listOfStrings = new List<string>() { "beef", "buns" };

        [TestMethod]
        public void MenuRepository_AddMenuItemToList_ShouldIncreaseCountByOne()
        {
            //Arrange
            menu = new Menu(5, "Hamburger", "Burger between buns", listOfStrings, 5.99m);
            list = _menuRepo.GetMenuList();
            _menuRepo.AddMenuItemToList(menu);

            //Act
            var actual = list.Count;
            var expected = 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
