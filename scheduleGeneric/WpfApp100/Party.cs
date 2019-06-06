using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp100
{
    //Removed Abstract
    abstract public class Party : IParty
    {
        // PRIVATE VARIABLES
        private string customerName = String.Empty;
        private string customerCity = String.Empty;
        private int averageAge = 0;
        private int partyDay = 0;
        private PartyDelegate caterer = null;

        // Prepare the delegate when the party is created
        public Party()
        {
            PrepareDelegate();
        }

        public Party(string customerName, string customerCity, int averageAge, int partyDay)
        {
            CustomerName = customerName;
            CustomerCity = customerCity;
            AverageAge = averageAge;
            PartyDay = partyDay;
            PrepareDelegate();
        }

        // PROPERTIES of data members
        public string CustomerName { get => customerName; set => customerName = value; }
        public string CustomerCity { get => customerCity; set => customerCity = value; }
        public int AverageAge { get => averageAge; set => averageAge = value; }
        public int PartyDay { get => partyDay; set => partyDay = value; }
        [XmlIgnore]
        public PartyDelegate Caterer { get => caterer; set => caterer = value; }

        // METHODS implemented according with the Interface and to be inherited by derived classes
        public virtual void PrepareFood()
        {
            //Console.WriteLine("Method of the Base Class named PrepareFood() executed.");
        }
        public virtual void DeliverFood()
        {
            //Console.WriteLine("Method of the Base Class named DeliverFood() executed.");
        }
        public virtual void SetUpTables()
        {
            //Console.WriteLine("Method of the Base Class named SetUpTables() executed.");
        }
        public virtual void CleanUp()
        {
            //Console.WriteLine("Method of the Base Class named CleanUp() executed.");
        }

        // method to be inherited by derived classes and permit them to implement specific tasks
        public abstract void SpecificTasks();

        public void PrepareDelegate()
        {
            Caterer += PrepareFood;
            Caterer += DeliverFood;
            Caterer += SetUpTables;
            Caterer += CleanUp;
            Caterer += SpecificTasks;
        }

        // override of ToSTring() to show custom message
        public override string ToString()
        {
            return string.Format("Customer: {0}, City: {1}, Age: {2}, Day: {3}", CustomerName, CustomerCity, AverageAge, PartyDay);
        }

        // implementing the ability to sort the list of parties
        public int CompareTo(IParty other)
        {
            return PartyDay.CompareTo(other.PartyDay);
        }
    }
}
