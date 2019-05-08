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

namespace First_App
{

    public partial class MainWindow : Window
    {
        private List<string> listOfInput = new List<string>();

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
            };

        }

        private void ButtonCaptured(object sender, RoutedEventArgs e)
        {
            var input = ((Button)sender).Tag.ToString();

            if (input == "C")
            {
                RemoveChar();
            }
            else if (input == "AC" && input.Length > 0)
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
            if (screen.Content.ToString() == "0")
            {
                screen.Content = "";
            }

            if (listOfInput.Count >= 13)
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

        }

    }
}
