using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_POCO
{
    public class Outing
    {
        public int ID { get; set; }
        public string OutingTitle { get; set; }
        public OutingType TypeOfOuting { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime OutingDate { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; set; }

        public Outing() { }
        public Outing(string outingTitle, OutingType typeOfOuting, int numberOfAttendees, DateTime outingDate, decimal costPerPerson, decimal totalCost)
        {
            OutingTitle = outingTitle;
            TypeOfOuting = typeOfOuting;
            OutingDate = outingDate;
            NumberOfAttendees = numberOfAttendees;
            CostPerPerson = costPerPerson;
            TotalCost = totalCost;
        }
    }
}
