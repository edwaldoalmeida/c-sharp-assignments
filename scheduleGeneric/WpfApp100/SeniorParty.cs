using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp100
{
    public class SeniorParty : Party
    {
        // CONSTRUCTORS
        public SeniorParty()
        {

        }
        public SeniorParty(string customerName, string customerCity, int averageAge, int partyDay) : base(customerName, customerCity, averageAge, partyDay)
        {
            
        }

        // METHODS
        public override void SpecificTasks()
        {
            CheckSuggarOnContentFood();
        }
        public void CheckSuggarOnContentFood()
        {
            //Console.WriteLine("Method of the SeniorParty Class named checkSuggarOnContentFood() executed.");
        }

        // override of ToSTring() to show custom message
        public override string ToString()
        {
            return string.Format("Day {0}, Customer: {1}, City: {2}, SENIOR party", this.PartyDay, this.CustomerName, this.CustomerCity);
        }
    }
}
