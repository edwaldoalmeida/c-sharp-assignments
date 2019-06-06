using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp100
{
    public class ChildParty : Party
    {
        // CONSTRUCTORS
        public ChildParty()
        {
            
        }
        public ChildParty(string customerName, string customerCity, int averageAge, int partyDay) : base(customerName, customerCity, averageAge, partyDay)
        {

        }

        // METHODS
        public override void SpecificTasks()
        {
            GetUnbreakableDishes();
        }
        public void GetUnbreakableDishes()
        {
            //Console.WriteLine("Method of the ChildParty Class named getUnbreakableDishes() executed.");
        }

        // override of ToSTring() to show custom message
        public override string ToString()
        {
            return string.Format("Day {0}, Customer: {1}, City: {2}, CHILD party", this.PartyDay, this.CustomerName, this.CustomerCity);
        }
    }
}
