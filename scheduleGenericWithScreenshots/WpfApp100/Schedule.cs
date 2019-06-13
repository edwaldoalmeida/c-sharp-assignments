using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace WpfApp100
{
    public enum ScheduleBoundaries { firstDay = 1, lastDay = 31 }

    public class typeSchedule
    {
        private ObservableCollection<Party> partyList;

        // PROPERTIES
        [XmlArray("Parties")]
        [XmlArrayItem("Party"),
            XmlArrayItem(Type = typeof(ChildParty)),
            XmlArrayItem(Type = typeof(AdultParty)),
            XmlArrayItem(Type = typeof(SeniorParty))]
        public ObservableCollection<Party> PartyList { get => partyList; set => partyList = value; }
        // removed "private" of set
        public typeSchedule Schedule { get; set; }

        // CONSTRUCTORS
        public typeSchedule()
        {
            this.PartyList = new ObservableCollection<Party>();
        }
        public typeSchedule(ObservableCollection<Party> list)
        {
            this.PartyList = list;
        }

        // INDEXER definition
        public IParty this[int i]
        {
            get { return PartyList[i]; }
        }

        // PUBLIC METHODS
        public Boolean AddParty(string inCustomerName, string inCustomerCityChoice, int inAverageAge, int inPartyDay)
        {
            // receive data from the form
            string customerName = inCustomerName;
            string customerCityChoice = inCustomerCityChoice;
            int averageAge = inAverageAge;
            int partyDay = inPartyDay;

            if (IsDateAvailable(partyDay)){
                // create a new party based on the type of party
                if (averageAge >= 60)
                {
                    PartyList.Add(new SeniorParty(customerName, customerCityChoice, averageAge, partyDay));
                }
                else if (averageAge > 26)
                {
                    PartyList.Add(new AdultParty(customerName, customerCityChoice, averageAge, partyDay));
                }
                else
                {
                    PartyList.Add(new ChildParty(customerName, customerCityChoice, averageAge, partyDay));
                }
                return true;
            } else
            {
                MessageBox.Show("This date is NOT available. Please, try another date.");
                return false;
            }
        }
        public void ClearSchedule()
        {
            PartyList.Clear();
        }
        public void SaveScheduleXMLSerializer()
        {
            /// <summary>
            /// Method that saves the Schedule to a XML File using XmlSerializer
            /// This is the teacher requirement
            /// Implemented for the first time in the Assignment #5
            /// </summary>

            string dir = @"data";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                MessageBox.Show("Directory CREATED.");
            }

            // File creation, if it doesn't exist
            string filePath = @"data\scheduleXMLserialized.xml";
            //if (!File.Exists(filePath))
            //{
            //    var myFile = File.Create(filePath);
            //    myFile.Close();
            //    MessageBox.Show("File CREATED.");
            //}

            //typeSchedule myList = Schedule; // this way?
            //List<Party> myList = PartyList;
            XmlSerializer serializer = new XmlSerializer(typeof(typeSchedule)); // this way?
            TextWriter writer = new StreamWriter(filePath);
            serializer.Serialize(writer, this);
            //writer.Close(); // is it needed?

            MessageBox.Show("Schedule SAVED to XML using XmlSerializer.");

        }
        public void RestoreScheduleXMLSerializer()
        {
            try {

                string filePath = @"data\scheduleXMLserialized.xml";
                
                typeSchedule myList;

                XmlSerializer serializer = new XmlSerializer(typeof(typeSchedule));

                using (TextReader reader = new StreamReader(filePath))
                {
                    myList = (typeSchedule)serializer.Deserialize(reader);
                }

                PartyList = myList.PartyList;

                //MessageBox.Show("Schedule RESTORED from XML using XmlSerializer.");

            }
            catch (Exception)
            {
                MessageBox.Show("File doesn't exist.");
            }

        }
        public void Filter(string name, string city)
        {
            //1st: List all elements of PartyList
            //var query = from p in PartyList
            //            select p;

            //2nd: name
            //var query = from p in PartyList
            //            where p.CustomerName == "Eddie"
            //            select p;

            //3rd: date (needs int)
            //var query = from p in PartyList
            //            where p.PartyDay == date
            //            select p;

            //4th: Name OR City

            //string comparisonand = "&&";
            //string comparisonor = "||";

            //if (name != "") (comparisonand) (city != "")

            

            if ((name != "") || (city != ""))
            {
                var query = from p in PartyList
                            //where p.CustomerName == name || p.CustomerCity == city
                            where p.CustomerName.Equals(name, StringComparison.OrdinalIgnoreCase) || p.CustomerCity.Equals(city, StringComparison.OrdinalIgnoreCase)
                            //orderby p.PartyDay
                            select p;

                ((MainWindow)System.Windows.Application.Current.MainWindow).theGrid.ItemsSource = query;

                //((MainWindow)System.Windows.Application.Current.MainWindow).theGrid.ItemsSource = "{Binding Path=PartyList}";

                //((MainWindow)System.Windows.Application.Current.MainWindow).textBlockView.Text = "";

                //foreach (IParty p in query)
                //{
                //    ((MainWindow)System.Windows.Application.Current.MainWindow).textBlockView.Text += p.ToString() + ".\n";
                //}
            }
            else
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).theGrid.ItemsSource = PartyList;
                //var query = from p in PartyList
                //            orderby p.PartyDay
                //            select p;
                //removed because I'm using the DataGrid now
                //ShowSchedule();
            }

        }

        // "SUPPORT" METHODS
        private int Count()
        {
            // method that returns the size of PartyList
            return PartyList.Count();
        }
        private Boolean IsDateAvailable(int day)
        {
            // method that checks if the date is available in the List (Schedule)
            if (FindPartyIndex(day) != -1)
            {
                return false;
            }
            return true;
        }
        private int FindPartyIndex(int day)
        {
            // method that returns the index of a party in the List
            for (int i = 0; i < this.Count(); i++)
            {
                if (this[i].PartyDay == day)
                {
                    return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// To Be Removed (TBR)
        /// </summary>
        public void SaveScheduleBinary()
        {
            /// <summary>
            /// Method that saves the Schedule to a Binary File
            /// Implemented for the first time in the Assignment #4
            /// </summary>
            
            // Directory creation, if it doesn't exist
            string dir = @"data";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                MessageBox.Show("Directory CREATED.");
            }

            // File creation, if it doesn't exist
            string filePath = @"data\scheduleBIN";
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
                string city = "";
                int age = 0;
                int day = 0;

                for (int i = 0; i < this.Count(); i++)
                {
                    name = this[i].CustomerName;
                    bw.Write(name);

                    city = this[i].CustomerCity;
                    bw.Write(city);

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
                MessageBox.Show("Schedule SAVED to BINARY.");
            }
        }
        public void RestoreScheduleBinary()
        {
            /// <summary>
            /// Method that restores the Schedule from a Binary File
            /// Implemented for the first time in the Assignment #4
            /// </summary>

            string filePath = @"data\scheduleBIN";

            FileStream fs = null;

            if (File.Exists(filePath))
            {
                try
                {
                    fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    string name = "";
                    string city = "";
                    int age = 0;
                    int day = 0;

                    PartyList.Clear();

                    // while not end of file
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        name = br.ReadString();
                        city = br.ReadString();
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
                    MessageBox.Show("Schedule RESTORED from BINARY file.");
                    //ShowSchedule();
                }
            }
            else
            {
                MessageBox.Show("BINARY File does not exist. Try saving some data before restoring.");
            }
        }
        public void SaveScheduleXMLRW()
        {
            /// <summary>
            /// Method that saves the Schedule to a XML File using XmlWriter
            /// It's not teacher requirement, but I decided to implement to see how it works
            /// Implemented for the first time in the Assignment #5
            /// </summary>

            // Directory creation, if it doesn't exist
            string dir = @"data";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                MessageBox.Show("Directory CREATED.");
            }

            // File creation, if it doesn't exist
            string filePath = @"data\scheduleXML.xml";
            //if (!File.Exists(filePath))
            //{
            //    var myFile = File.Create(filePath);
            //    myFile.Close();
            //    MessageBox.Show("File CREATED.");
            //}

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            XmlWriter writer = XmlWriter.Create(filePath, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("Parties");

            foreach (Party p in PartyList)
            {
                writer.WriteStartElement("Party");
                writer.WriteElementString("CustomerName", p.CustomerName);
                writer.WriteElementString("CustomerCity", p.CustomerCity);
                writer.WriteElementString("AverageAge", p.AverageAge.ToString());
                writer.WriteElementString("PartyDay", p.PartyDay.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
            MessageBox.Show("Schedule SAVED to XML using XmlWriter.");
        }
        public void RestoreScheduleXMLRW()
        {
            /// <summary>
            /// Method that restores the Schedule from a XML File using XmlReader
            /// It's not teacher requirement, but I decided to implement to see how it works
            /// Implemented for the first time in the Assignment #5
            /// </summary>

            string filePath = @"data\scheduleXML.xml";

            if (File.Exists(filePath))
            {
                try
                {
                    PartyList.Clear();
                    typeSchedule myList = Schedule;

                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.IgnoreWhitespace = true;
                    settings.IgnoreComments = true;

                    XmlReader reader = XmlReader.Create(filePath, settings);

                    if (reader.ReadToDescendant("Party"))
                    {
                        do
                        {
                            reader.ReadStartElement("Party");
                            string name = reader.ReadElementContentAsString();
                            string city = reader.ReadElementContentAsString();
                            int age = reader.ReadElementContentAsInt();
                            int day = reader.ReadElementContentAsInt();
                            AddParty(name, city, age, day);
                        } while (reader.ReadToNextSibling("Party"));
                        reader.Close();
                    }
                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.ToString());
                }
                finally
                {
                    //fs.Close();
                    //MessageBox.Show("Schedule RESTORED from XML.");
                    //ShowSchedule();
                }
            }
            else
            {
                MessageBox.Show("XML File does not exist. Try saving some data before restoring.");
            }
        }
        public void ShowSchedule()
        {
            //((MainWindow)System.Windows.Application.Current.MainWindow).textBlockView.Text = "";

            //if (PartyList.Count() != 0)
            //{
            //    for (int i = 0; i < PartyList.Count(); i++)
            //    {
            //        ((MainWindow)System.Windows.Application.Current.MainWindow).textBlockView.Text += PartyList[i].ToString() + ".\n";
            //    }
            //} else
            //{
            //    ((MainWindow)System.Windows.Application.Current.MainWindow).textBlockView.Text = "Schedule is empty.";
            //}
        }
    }
}