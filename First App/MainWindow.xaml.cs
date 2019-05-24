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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using org.mariuszgromada.math.mxparser;
using First_App.AppHelper;

namespace First_App
{

    public partial class MainWindow : Window
    {
        private List<string> listOfInput = new List<string>();
        private List<string> IgnoreChar = new List<string> { "=", "-", "+", "?", "`", "~" };

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            int keyVal = (int)e.Key;
            int value = -1;

            if ((keyVal >= (int)Key.D0 && keyVal <= (int)Key.D9))
            {
                value = (int)e.Key - (int)Key.D0;
            }

            else if (keyVal >= (int)Key.NumPad0 && keyVal <= (int)Key.NumPad9)
            {
                value = (int)e.Key - (int)Key.NumPad0;
            }

            if (value != -1)
            {
                ShowDigits(value.ToString());
            }

            if (keyVal == 2)
            {
                RemoveChar();
            }

            else if (keyVal == 6 || keyVal == 8)
            {
                ShowDigits("=");
            }

            //getting the positive values
            else if (keyVal == 141 || keyVal == 85)
            {
                ShowDigits("+");
            }

        }

        private void ButtonCaptured(object sender, RoutedEventArgs e)
        {
            var input = ((Button)sender).Tag.ToString();

            if (input == "C")
            {
                RemoveChar();
            }

            else if (input == "AC" &&
                input.Length > 0)
            {
                listOfInput.Clear();
                screen.Content = "0";
            }
            else
            {
                ShowDigits(input);
            }
        }

        private void ShowDigits(string input)
        {
            var displayedNumber = screen.Content.ToString().Count();

            if (screen.Content.ToString() == "0")
            {
                screen.Content = "";
            }

            if (input == "=" &&
                listOfInput.Any())
            {


                var screenContent = screen.Content.ToString().Replace("X", "*").Replace("mod", "#");

                if (screen.Content.ToString().Contains("sqrt"))
                {
                    screenContent = screenContent.Replace("sqrt", "sqrt(") + ")";
                }
                if (input == "=" && menus.SelectedIndex == -1)
                {
                    var inputAsint = Convert.ToInt32(screen.Content);
                    screen.Content = BinaryOperation.GetResult(inputAsint);
                }
                else
                {
                    screen.Content = CalculateOperations.GetResult(screenContent);
                }

                listOfInput.Clear();
            }

            else if (displayedNumber >= 13)
            {
                MessageBox.Show("Maximum Input exceed", "Input limit", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            else
            {
                listOfInput.Add(input);
                screen.Content += input.ToString();
            }

        }

        private void RemoveChar()
        {
            var contentString = screen.Content.ToString();

            int lenghtOflebel = contentString.Count();

            int inputLength = listOfInput.Count();

            if (lenghtOflebel > 0 && inputLength > 0)
            {
                listOfInput.RemoveAt(inputLength - 1);
                screen.Content = contentString.Remove(lenghtOflebel - 1);
            }

            if (listOfInput.Count == 0)
            {
                screen.Content = "0";
            }
        }


        private void NavigateMenu(object sender, RoutedEventArgs e)
        {
            DoubleAnimation menuAnimation = new DoubleAnimation();

            if (menus.Width == 0)
            {
                menuAnimation.From = 0;
                menuAnimation.To = 206;
            }
            else
            {
                menuAnimation.From = 206;
                menuAnimation.To = 0;
            }

            menuAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            menus.BeginAnimation(WidthProperty, menuAnimation);
        }

        private void SwitchOperation(object sender, RoutedEventArgs e)
        {
            var input = ((Button)sender).Tag.ToString();

            if (input == Operations.Decimal.ToString())
            {
                NavigateMenu(sender, e);
                Intial();
                seletlist.Visibility = Visibility.Visible;
            }

        }

        private void Button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ShowDigits("=");
            e.Handled = true;
        }

        private void Intial()
        {
            List<string> allowedButtons =
                new List<string>
            {
                "1","2","3","4","5","6","7","8","9","0","C","AC","=","int","menu","to"
            };

            foreach (var child in mainGrid.Children)
            {
                var button = child as Button;

                if (button != null)
                {
                    if (!allowedButtons.Any(p => p == button.Tag.ToString()))
                    {
                        button.Visibility = Visibility.Collapsed;
                    }
                    if (button.Content.ToString() == "Int" ||
                        button.Tag.ToString() == "to")
                    {
                        button.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void ChangeOption(object sender, SelectionChangedEventArgs e)
        {
            var selectedValue = (ComboBoxItem)(seletlist.SelectedItem);

        }
    }
}
