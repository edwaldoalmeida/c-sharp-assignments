using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApp100
{
    public enum Cities { Kitchener = 1, Waterloo = 2, Cambridge = 3 };
    public enum ScheduleBoundaries { firstDay = 1, lastDay = 31 }
    class Schedule
    {
        static private List<IParty> PartyList;

        // CONSTRUCTORS
        public Schedule()
        {
            PartyList = new List<IParty>();
        }
        public Schedule(List<IParty> list)
        {
            PartyList = list;
        }

        // INDEXER definition
        public IParty this[int i]
        {
            get { return PartyList[i]; }
            set { PartyList[i] = value; }
        }

        // PUBLIC METHODS //
        public Boolean AddParty(string inCustomerName, int inCustomerCityChoice, int inAverageAge, int inPartyDay)
        {
            // variables initialization
            string customerName = string.Empty;
            var customerCity = Enum.GetValues(typeof(Cities));
            int customerCityChoice = 0;
            int averageAge = 0;
            int partyDay = 0;

            // receive data from the form
            customerName = inCustomerName;
            customerCityChoice = inCustomerCityChoice;
            averageAge = inAverageAge;
            partyDay = inPartyDay;

            if (IsDateAvailable(partyDay)){
                // create a new party based on the type of party
                if (averageAge >= 60)
                {
                    PartyList.Add(new SeniorParty(customerName, (Cities)customerCityChoice, averageAge, partyDay));
                }
                else if (averageAge > 26)
                {
                    PartyList.Add(new AdultParty(customerName, (Cities)customerCityChoice, averageAge, partyDay));
                }
                else
                {
                    PartyList.Add(new ChildParty(customerName, (Cities)customerCityChoice, averageAge, partyDay));
                }
                PartyList.Sort();
                return true;
            } else
            {
                MessageBox.Show("This date is NOT available. Please, try another date.");
                return false;
            }
        }
        public void ShowSchedule()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).textBlockView.Text = "";

            if (PartyList.Count() != 0)
            {
                for (int i = 0; i < PartyList.Count(); i++)
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).textBlockView.Text += PartyList[i].ToString() + ".\n";
                }
            } else
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).textBlockView.Text = "Schedule is empty.";
            }
        }
        public void ClearSchedule()
        {
            PartyList.Clear();
            ShowSchedule();
        }
        public void SaveSchedule()
        {
            // Directory creation, if it doesn't exist
            string dir = @"data";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                MessageBox.Show("Directory CREATED.");
            }

            // File creation, if it doesn't exist
            string filePath = @"data\schedule";
            if (!File.Exists(filePath))
            {
                var myFile = File.Create(filePath);
                myFile.Close();
                MessageBox.Show("File CREATED.");
            }

            // Writing to the file
            FileStream fs = null;
            try
            {
                // I decided to use "FileMode.Create" because ".OpenOrCreate" was generating some problems.
                // When the user did: save, clean schedule (list), insert repeated date and restore,
                // a problem ocurred because of duplicated dates, so I decided to overwrite the file
                // every time the list is save to the file
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);

                string name = "";
                Cities city = 0;
                int age = 0;
                int day = 0;

                for (int i = 0; i < this.Count(); i++)
                {
                    name = this[i].CustomerName;
                    bw.Write(name);

                    city = this[i].CustomerCity;
                    bw.Write((int)city);

                    age = this[i].AverageAge;
                    bw.Write(age);

                    day = this[i].PartyDay;
                    bw.Write(day);
                }
                bw.Close();
                
            } catch (IOException ioe)
            {
                MessageBox.Show(ioe.ToString());
            }
            finally
            {
                fs.Close();
                MessageBox.Show("Schedule SAVED.");
            }
        }
        public void RestoreSchedule()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).textBlockView.Text = "";

            string filePath = @"data\schedule";

            FileStream fs = null;

            if (File.Exists(filePath))
            {
                try
                {
                    fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    string name = "";
                    int city = 0;
                    int age = 0;
                    int day = 0;

                    PartyList.Clear();

                    // while not end of file
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        name = br.ReadString();
                        city = br.ReadInt32();
                        age = br.ReadInt32();
                        day = br.ReadInt32();
                        AddParty(name, city, age, day);
                    }
                    br.Close();
                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.ToString());
                }
                finally
                {
                    fs.Close();
                    MessageBox.Show("Schedule RESTORED.");
                    ShowSchedule();
                }
            }
            else
            {
                MessageBox.Show("File does not exist. Try saving some data before restoring.");
            }
        }

        // "SUPPORT" METHODS //
        // method that returns the size of PartyList
        private int Count()
        {
            return PartyList.Count();
        }

        // method that checks if the date is available in the List (Schedule)
        private Boolean IsDateAvailable(int day)
        {
            if (FindPartyIndex(day) != -1)
            {
                return false;
            }
            return true;
        }

        // method that returns the index of a party in the List
        private int FindPartyIndex(int day)
        {
            for (int i = 0; i < this.Count(); i++)
            {
                if (this[i].PartyDay == day)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}