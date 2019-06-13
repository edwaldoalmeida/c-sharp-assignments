using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp100
{
    class City
    {
        private int id;
        private string name;

        public City()
        {
        }

        public City(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        // "dummy" class (alias for the List<>) to be used in the binding to the select
        public class Cities : List<City> { }

    }
}
