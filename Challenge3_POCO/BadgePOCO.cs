using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_POCO
{
    

    public class Badge
    {
        //Dictionary<int, List<string>> badgeDictionary = new Dictionary<int, List<string>>();

        public int BadgeID { get; set; }
        public string BadgeName { get; set; }
        public List<string> AccessibleDoors { get; set; }

        public Badge() { }
        public Badge(int badgeID, string badgeName, List<string> accessibleDoors)
        {
            BadgeID = badgeID;
            BadgeName = badgeName;
            AccessibleDoors = accessibleDoors;
        }
    }
}
