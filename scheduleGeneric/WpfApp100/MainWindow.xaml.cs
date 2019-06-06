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

namespace WpfApp100
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        /// this variable will control how many fields are red / with input errors
        /// The event is only added to the Schedule when this var == 0
        /// probably there is a better way to do this check, but this was the solution that came up in my mind
        //public int redFields = 0;

        public typeSchedule Schedule;

        public MainWindow()
        {
            InitializeComponent();
            
            Schedule = new typeSchedule(new System.Collections.ObjectModel.ObservableCollection<Party>());

            DataContext = Schedule;

            // Implementing Data Island for the Select of Cities
            List<City> cities = new List<City>();
            cities.Add(new City(1, "Kitchener"));
            cities.Add(new City(2, "Waterloo"));
            cities.Add(new City(3, "Cambridge"));
            ListBoxCities.ItemsSource = cities;
            ListBoxCities.DisplayMemberPath = "Name";
            ListBoxCities.SelectedIndex = 0;

            this.theGrid.ItemsSource = Schedule.PartyList;

            textBoxAverageAge.Text = "";
            textBoxPartyDay.Text = "";
            textBoxName.Focus();

        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            if ((IsPositiveInteger(textBoxAverageAge.Text)) && (IsBetweenScheduleBoundaries(textBoxPartyDay.Text)))
            {
                try
                {
                    dynamic theCity = ListBoxCities.SelectedItem as dynamic;
                    string CityName = theCity.Name;

                    Schedule.AddParty(textBoxName.Text, CityName, int.Parse(textBoxAverageAge.Text), int.Parse(textBoxPartyDay.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Registration UNsuccessfull.");
                }
            }

            //// Check if there is some blank field (probably, it would be more elegant to have a function to do this )
            //if ((textBoxName.Text != "")
            //    //&& (textBoxCity.Text != "")
            //    && (ListBoxCities.SelectedItem != null)
            //    && (textBoxAverageAge.Text != "")
            //    && (textBoxPartyDay.Text != ""))
            //{
            //    // to get the selected city on the ListBox (aff!!!)
            //    dynamic theCity = ListBoxCities.SelectedItem as dynamic;
            //    string CityName = theCity.Name;

            //    if (redFields == 0)
            //    {
            //        if (Schedule.AddParty(textBoxName.Text, CityName, int.Parse(textBoxAverageAge.Text), int.Parse(textBoxPartyDay.Text)))
            //        {
            //            //MessageBox.Show("Party added.");
            //            Schedule.ShowSchedule();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please, check red fields.");
            //    }
            //} else
            //{
            //    MessageBox.Show("Please, all fields must be filled.");
            //}


            //TBR:

            //Schedule.Filter("", "");
            // Refresh the grid:
            //theGrid.Items.Refresh();
            // update controls on the interface:
            //theGrid.update();
            //theGrid.refresh();
            //theGrid.DataContext = Schedule;
            //DataContext = Schedule;
            //listDays.Items.Refresh();
            //listParties.Items.Refresh();

        }
        private void buttonViewSchedule_Click(object sender, RoutedEventArgs e)
        {
            //Schedule.ShowSchedule();
        }
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            //Schedule.SaveScheduleBinary();
            //Schedule.SaveScheduleXMLRW();
            Schedule.SaveScheduleXMLSerializer();
        }
        private void buttonRestore_Click(object sender, RoutedEventArgs e)
        {
            
            //Schedule.RestoreScheduleBinary();
            //Schedule.RestoreScheduleXMLRW();
            Schedule.RestoreScheduleXMLSerializer();

            this.theGrid.ItemsSource = Schedule.PartyList;

        }
        private void buttonClearFields_Click(object sender, RoutedEventArgs e)
        {
            textBoxName.Text = "";
            //textBoxCity.Text = "";
            textBoxAverageAge.Text = "";
            textBoxPartyDay.Text = "";
            textBoxName.Focus();
        }
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            //Schedule.LINQtest(int.Parse(txtLINQtest.Text));
            Schedule.Filter(txtFilterName.Text, txtFilterCity.Text);
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Checked");
            //txtLINQname. = false;
            Schedule.Filter(txtFilterName.Text, txtFilterCity.Text);

        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Unchecked");
            Schedule.Filter("", "");

        }
        private void btnClearFilterName_Click(object sender, RoutedEventArgs e)
        {
            txtFilterName.Text = "";
            Schedule.Filter(txtFilterName.Text, txtFilterCity.Text);
        }
        private void btnClearFilterCity_Click(object sender, RoutedEventArgs e)
        {
            txtFilterCity.Text = "";
            Schedule.Filter(txtFilterName.Text, txtFilterCity.Text);
        }
        private void txtFilterName_KeyUp(object sender, KeyEventArgs e)
        {
            Schedule.Filter(txtFilterName.Text, txtFilterCity.Text);
        }
        private void txtFilterCity_KeyUp(object sender, KeyEventArgs e)
        {
            Schedule.Filter(txtFilterName.Text, txtFilterCity.Text);
        }
        private void buttonClearSchedule_Click(object sender, RoutedEventArgs e)
        {
            Schedule.ClearSchedule();
            checkBoxFilterBy.IsChecked = false;
        }
        private static Boolean IsPositiveInteger(string value)
        {
            if (int.TryParse(value, out int x) && x > 0)
            {
                return true;
            }
            return false;
        }
        private static Boolean IsBetweenScheduleBoundaries(string value)
        {
            if (int.TryParse(value, out int x) && (x >= (int)ScheduleBoundaries.firstDay) && (x <= (int)ScheduleBoundaries.lastDay))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// TO BE REMOVED
        /// </summary>
        protected void textBoxAverageAge_ValidationError(object sender, ValidationErrorEventArgs e)
        {
        //    // implementing conversion/error handling
        //    // but I don't know yet why this method exists and what it does...
        //    MessageBox.Show((string)e.Error.ErrorContent);
        }
        private void textBoxAverageAge_LostFocus(object sender, RoutedEventArgs e)
        {
            /// Field AVERAGE AGE validation
            /// 
            //if (!IsPositiveInteger(textBoxAverageAge.Text))
            //{
            //    if (textBoxAverageAge.Foreground != Brushes.Red)
            //    {
            //        textBoxAverageAge.Foreground = Brushes.Red;
            //        redFields += 1;
            //    }
            //}
            //else
            //{
            //    if (textBoxAverageAge.Foreground == Brushes.Red)
            //    {
            //        textBoxAverageAge.Foreground = Brushes.Black;
            //        redFields -= 1;
            //    }
            //};
        }
        private void textBoxPartyDay_LostFocus(object sender, RoutedEventArgs e)
        {
            /// Field PARTY DAY validation
            /// 
            //if (!IsBetweenScheduleBoundaries(textBoxPartyDay.Text))
            //{
            //    if (textBoxPartyDay.Foreground != Brushes.Red)
            //    {
            //        textBoxPartyDay.Foreground = Brushes.Red;
            //        redFields += 1;
            //    }
            //}
            //else
            //{
            //    if (textBoxPartyDay.Foreground == Brushes.Red)
            //    {
            //        textBoxPartyDay.Foreground = Brushes.Black;
            //        redFields -= 1;
            //    }
            //};
        }
        private void buttonClearView_Click(object sender, RoutedEventArgs e)
        {
            //textBlockView.Text = "";
        }

    }
}
