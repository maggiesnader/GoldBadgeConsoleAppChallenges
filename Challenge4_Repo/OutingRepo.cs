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
            foreach (Outing outing in _ListOfOutings)
            {
                if (outing.TypeOfOuting == typeOfOuting)
                {
                    Console.WriteLine($"\n{outing.OutingTitle}:\n" +
                    $"ID Number: {outing.ID}\n" +
                    $"Type: {outing.TypeOfOuting}\n" +
                    $"\tDate: {outing.OutingDate}\n" +
                    $"\tNumber of Attendees: {outing.NumberOfAttendees}\n" +
                    $"\tCost Per Person: ${outing.CostPerPerson}\n" +
                    $"\tTotal Cost: ${outing.TotalCost}");
                }
            }
            return null;
        }

        public bool GetOutingCostTotalByType(OutingType typeOfOuting)
        {
            decimal sum = _ListOfOutings.Where(x => x.TypeOfOuting == typeOfOuting).Sum(x => x.TotalCost);
            Console.WriteLine($"\n\nTotal Cost of Outings: ${sum}");
            return true;
        }

        public bool GetTotalCostOfAllOutings(List<Outing> _ListOfOutings)
        {
            decimal sum = _ListOfOutings.Select(x => x.TotalCost).Sum();
            _ListOfOutings.Add(new Outing() { TotalCost = sum });
            Console.WriteLine($"\n\nTotal Cost of All Outings: ${sum}");
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
