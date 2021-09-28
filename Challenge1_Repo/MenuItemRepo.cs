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

        //CREATE - ADD
        public bool AddMenuItemToList(MenuItem itemToBeAdded)
        {
            if(itemToBeAdded != null)
            {
                _ListOfMenuItems.Add(itemToBeAdded);
                return true;
            }
            return false;
        }

        //READ - VIEW
        public List<MenuItem> ViewAllMeals()
        {
            return _ListOfMenuItems;
        }

        public MenuItem ViewMealByNumber(int mealNumber)
        {
            foreach(MenuItem meal in _ListOfMenuItems)
            {
                if(meal.MealNumber == mealNumber)
                {
                    return meal;
                }
            }
            return null;
        }

        //UPDATE--NOT REQUIRED ON PROMPT
        public bool UpdateExistingMenuItem(int mealNumber, MenuItem newMenuItemInfo)
        {
            //find the content
            MenuItem oldMenuItemInfo = ViewItemByNumber(mealNumber);
            //update the content
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

        //DELETE
        public bool RemoveMenuItem (int mealNumber)
        {
            MenuItem meal = ViewItemByNumber(mealNumber);
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
