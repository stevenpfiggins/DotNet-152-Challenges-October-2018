using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class MenuRepository
    {
        List<Menu> _menuList = new List<Menu>();

        public void AddMenuItemToList(Menu menuItem)
        {
            _menuList.Add(menuItem);
        }

        public List<Menu> GetMenuList()
        {
            return _menuList;
        }
    }
}
