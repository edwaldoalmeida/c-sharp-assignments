using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp100
{
    public delegate void PartyDelegate();

    // implementing IComparable for the ability to sort the list of parties
    // implemented in the Interface because the list of parties (Schedule) use the Interface
    public interface IParty : IComparable<IParty>
    {
        // METHODS that are to be implemented by classes that use this Interface
        void PrepareFood();
        void DeliverFood();
        void SetUpTables();
        void CleanUp();

        // PROPERTIES of data members, including the Delegate
        PartyDelegate Caterer { get; set; }
        string CustomerName { get; set; }
        Cities CustomerCity { get; set; }
        int AverageAge { get; set; }
        int PartyDay { get; set; }

    }
}
