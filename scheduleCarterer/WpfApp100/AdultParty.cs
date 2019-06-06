using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp100
{
    class AdultParty : Party
    {
        // CONSTRUCTORS
        public AdultParty()
        {
            
        }
        public AdultParty(string customerName, Cities customerCity, int averageAge, int partyDay) : base (customerName, customerCity, averageAge, partyDay)
        {
            
        }

        // METHODS
        public override void SpecificTasks()
        {
            DeliverHardLiquor();
        }
        public void DeliverHardLiquor()
        {
            //Console.WriteLine("Method of the AdultParty Class named deliverHardLiquor() executed.");
        }

        // override of ToSTring() to show custom message
        public override string ToString()
        {
            return string.Format("Day {0}, Customer: {1}, City: {2}, ADULT party", this.PartyDay, this.CustomerName, this.CustomerCity);
        }
    }
}
