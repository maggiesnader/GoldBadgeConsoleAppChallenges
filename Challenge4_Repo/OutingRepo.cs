using Challenge4_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_Repo
{
    public class OutingRepo
    {
        private List<Outing> _ListOfOutings = new List<Outing>();
        private int _idCounter = default;

        public bool AddOutingToList(Outing outingToBeAdded)
        {
            if (outingToBeAdded != null)
            {
                outingToBeAdded.ID = ++_idCounter;
                _ListOfOutings.Add(outingToBeAdded);
                return true;
            }
            return false;
        }

        public List<Outing> ViewAllOutings()
        {
            return _ListOfOutings;
        }

        public Outing ViewOutingByID(int id)
        {
            foreach (Outing outing in _ListOfOutings)
            {
                if (outing.ID == id)
                {
                    return outing;
                }
            }
            return null;
        }

        public Outing ViewOutingByType(OutingType typeOfOuting)
        {
            Console.WriteLine("{0, -7} {1, -25} {2, -15} {3, -25} {4, -10} {5, -15} {6, -15}",
                        "ID#", "Title", "Type", "Date", "#Guests", "Cost/Person", "Event Cost");

            foreach (Outing outing in _ListOfOutings)
            {
                if (outing.TypeOfOuting == typeOfOuting)
                {
                    Console.WriteLine("{0, -7} {1, -25} {2, -15} {3, -25} {4, -10} {5, -15} {6, -15}",
                        outing.ID, outing.OutingTitle, outing.TypeOfOuting, outing.OutingDate, outing.NumberOfAttendees, "$" + outing.CostPerPerson, "$" + outing.TotalCost);
                }
            }
            return null;
        }

        public bool GetOutingCostTotalByType(OutingType typeOfOuting)
        {
            decimal sum = _ListOfOutings.Where(x => x.TypeOfOuting == typeOfOuting).Sum(x => x.TotalCost);
            Console.WriteLine("\n");
            Console.WriteLine("{0, 111}", $"Total Cost of {typeOfOuting} Outings: ${sum}");
            return true;
        }

        public bool GetTotalCostOfAllOutings(List<Outing> _ListOfOutings)
        {
            decimal sum = _ListOfOutings.Select(x => x.TotalCost).Sum();
            Console.WriteLine("\n");
            Console.WriteLine("{0, 111}", $"Total Cost of All Outings: ${sum}");
            return true;
        }

        public bool UpdateExistingOuting(int id, Outing updatedOutingInfo)
        {
            Outing oldOutingInfo = ViewOutingByID(id);

            if (oldOutingInfo != null)
            {
                oldOutingInfo.OutingTitle = updatedOutingInfo.OutingTitle;
                oldOutingInfo.TypeOfOuting = updatedOutingInfo.TypeOfOuting;
                oldOutingInfo.OutingDate = updatedOutingInfo.OutingDate;
                oldOutingInfo.NumberOfAttendees = updatedOutingInfo.NumberOfAttendees;
                oldOutingInfo.CostPerPerson = updatedOutingInfo.CostPerPerson;
                oldOutingInfo.TotalCost = updatedOutingInfo.TotalCost;
                return true;
            }
            return false;
        }

        public bool RemoveOutingFromInventory(int id)
        {
            Outing outing = ViewOutingByID(id);
            if (outing == null)
            {
                return false;
            }
            int initialCount = _ListOfOutings.Count;
            _ListOfOutings.Remove(outing);
            if (initialCount > _ListOfOutings.Count)
            {
                return true;
            }
            return false;
        }
    }
}
