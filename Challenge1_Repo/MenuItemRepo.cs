using Challenge1_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Repo
{
    public class MenuItemRepo
    {
        private List<MenuItem> _ListOfMenuItems = new List<MenuItem>();
        public bool AddMenuItemToList(MenuItem itemToBeAdded)
        {
            if(itemToBeAdded != null)
            {
                _ListOfMenuItems.Add(itemToBeAdded);
                return true;
            }
            return false;
        }
        public List<MenuItem> ViewAllMeals()
        {
            return _ListOfMenuItems;
        }
        public MenuItem ViewMealByNumber(string mealNumber)
        {
            foreach(MenuItem meal in _ListOfMenuItems)
            {
                if(meal.MealNumber == mealNumber)
                {
                    return meal;
                }
            }return null;
        }
        public bool UpdateExistingMenuItem(string mealNumber, MenuItem newMenuItemInfo)
        {
            MenuItem oldMenuItemInfo = ViewMealByNumber(mealNumber);
            if(oldMenuItemInfo != null)
            {
                oldMenuItemInfo.MealNumber = newMenuItemInfo.MealNumber;
                oldMenuItemInfo.MealName = newMenuItemInfo.MealName;
                oldMenuItemInfo.MealDescription = newMenuItemInfo.MealDescription;
                oldMenuItemInfo.MealIngredients = newMenuItemInfo.MealIngredients;
                oldMenuItemInfo.MealPrice = newMenuItemInfo.MealPrice;
                return true;
            }
            return false;
        }
        public bool RemoveMenuItem (string mealNumber)
        {
            MenuItem meal = ViewMealByNumber(mealNumber);
            if(meal == null)
            {
                return false;
            }
            int initialCount = _ListOfMenuItems.Count;
            _ListOfMenuItems.Remove(meal);
            if(initialCount > _ListOfMenuItems.Count)
            {
                return true;
            }
            return false;
        }
    }
}
