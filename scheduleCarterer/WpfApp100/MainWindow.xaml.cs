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
        // this variable will control how many fields are red / with input errors
        // The event is only added to the Schedule when this var == 0
        // probably there is a better way to do this check, but this was the solution that came up in my mind
        int redFields = 0;

        Schedule Schedule = new Schedule();

        public MainWindow()
        {
            InitializeComponent();
            Run();
        }

        public void Run()
        {
            textBoxName.Focus();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            // Check if there is some blank field (probably, it would be more elegant to have a function to do this )
            if ((textBoxName.Text != "") && (textBoxCity.Text != "") && (textBoxAverageAge.Text != "") && (textBoxPartyDay.Text != ""))
            {
                if (redFields == 0)
                {
                    if (Schedule.AddParty(textBoxName.Text, int.Parse(textBoxCity.Text), int.Parse(textBoxAverageAge.Text), int.Parse(textBoxPartyDay.Text)))
                    {
                        MessageBox.Show("Party added.");
                    }
                }
                else
                {
                    MessageBox.Show("Please, check red fields.");
                }
            } else
            {
                MessageBox.Show("Please, all fields must be filled.");
            }
        }

        private void buttonViewSchedule_Click(object sender, RoutedEventArgs e)
        {
            Schedule.ShowSchedule();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            Schedule.SaveSchedule();
        }

        private void buttonRestore_Click(object sender, RoutedEventArgs e)
        {
            Schedule.RestoreSchedule();
        }

        private void buttonClearView_Click(object sender, RoutedEventArgs e)
        {
            textBlockView.Text = "";
        }

        private void buttonClearSchedule_Click(object sender, RoutedEventArgs e)
        {
            Schedule.ClearSchedule();
        }

        // Field CITY validation
        private void textBoxCity_LostFocus(object sender, RoutedEventArgs e)
        {
            // Check if city code informed is in the list of cities
            if (!IsBetweenCitiesBoundaries(textBoxCity.Text))
            {
                if (textBoxCity.Foreground != Brushes.Red)
                {
                    textBoxCity.Foreground = Brushes.Red;
                    redFields += 1;
                }
            }
            else
            {
                if (textBoxCity.Foreground == Brushes.Red)
                {
                    textBoxCity.Foreground = Brushes.Black;
                    redFields -= 1;
                }
            };
        }

        // Field AVERAGE AGE validation
        private void textBoxAverageAge_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsPositiveInteger(textBoxAverageAge.Text))
            {
                if (textBoxAverageAge.Foreground != Brushes.Red)
                {
                    textBoxAverageAge.Foreground = Brushes.Red;
                    redFields += 1;
                }
            }
            else
            {
                if (textBoxAverageAge.Foreground == Brushes.Red)
                {
                    textBoxAverageAge.Foreground = Brushes.Black;
                    redFields -= 1;
                }
            };
        }

        // Field PARTY DAY validation
        private void textBoxPartyDay_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsBetweenScheduleBoundaries(textBoxPartyDay.Text))
            {
                if (textBoxPartyDay.Foreground != Brushes.Red)
                {
                    textBoxPartyDay.Foreground = Brushes.Red;
                    redFields += 1;
                }
            }
            else
            {
                if (textBoxPartyDay.Foreground == Brushes.Red)
                {
                    textBoxPartyDay.Foreground = Brushes.Black;
                    redFields -= 1;
                }
            };
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

        private static Boolean IsBetweenCitiesBoundaries(string value)
        {
            int citiesLength = Enum.GetNames(typeof(Cities)).Length;

            if (int.TryParse(value, out int y) && (y > 0) && (y <= citiesLength))
            {
                return true;
            }
            return false;
        }

        private void buttonClearFields_Click(object sender, RoutedEventArgs e)
        {
            textBoxName.Text = "";
            textBoxCity.Text = "";
            textBoxAverageAge.Text = "";
            textBoxPartyDay.Text = "";
        }
    }
}
