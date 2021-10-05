using Challenge3_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Repo
{
    public class BadgeRepo
    {
        //private List<Badge> _ListOfBadges = new List<Badge>();
        Dictionary<int, List<string>> badgeDictionary = new Dictionary<int, List<string>>();
        var badge = new Dictionary<int, List<string>()
        {

        }
        private int _idCounter = default;

        //CREATE ADD
        public bool AddBadgeToDictionary(int badgeID, List<string> doorsToBeAdded)
        {
            if(doorsToBeAdded != null)
            {
                badgeID = ++_idCounter;
                badgeDictionary.Add(badgeID, doorsToBeAdded);
                return true;
            }
            return false;
        }

        //READ VIEW
        public Dictionary<int, List<string>> ViewAllBadges()
        {
            return badgeDictionary;
        }
        public Badge ViewBadgeByID(int ID)
        {
            if()
        }


        //UPDATE


        //DELETE
    }
}
