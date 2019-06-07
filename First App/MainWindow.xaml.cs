﻿using System;
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

        private OperationsUnit CurrentMenu = OperationsUnit.Standard;

        private NumberUnits ConvertionMethod;

        private PercentUnits SelectPercent;

        private WeightUnits FormMethod;

        private WeightUnits ToMethod;

        private TemperatureUnits SelectedTUnit;

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

                if (input == "=")
                {
                    if (CurrentMenu == OperationsUnit.Standard)
                    {
                        screen.Content = CalculateOperations.GetResult(screenContent);
                    }

                    else if (CurrentMenu == OperationsUnit.Decimal)
                    {
                        var inputAsint = Convert.ToInt32(screen.Content);
                        screen.Content = BinaryOperation.GetResult(inputAsint, ConvertionMethod);
                    }

                    else if (CurrentMenu == OperationsUnit.Percentage)
                    {
                        screen.Content = PercentOperation.GetResult(screenContent, SelectPercent);
                    }
                    else if (CurrentMenu == OperationsUnit.Weight)
                    {
                        screen.Content = WeightOperations.GetResult(screenContent, FormMethod, ToMethod);
                    }
                    else if (CurrentMenu == OperationsUnit.Temperature)
                    {
                        screen.Content = TemperatureOperations.GetResult(screenContent, SelectedTUnit);
                    }

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

            seletlist.Visibility = Visibility.Collapsed;
            percentOrDecimal.Visibility = Visibility.Collapsed;
            ToWeight.Visibility = Visibility.Collapsed;
            FromWeight.Visibility = Visibility.Collapsed;

            if (input == OperationsUnit.Decimal.ToString())
            {
                NavigateMenu(sender, e);
                IntialForDecimal();
                seletlist.Visibility = Visibility.Visible;
                CurrentMenu = OperationsUnit.Decimal;
            }
            else if (input == OperationsUnit.Percentage.ToString())
            {
                NavigateMenu(sender, e);
                IntialForPercent();
                percentOrDecimal.Visibility = Visibility.Visible;
                CurrentMenu = OperationsUnit.Percentage;
            }
            else if (input == OperationsUnit.Weight.ToString())
            {
                NavigateMenu(sender, e);
                IntialForWeight();
                ToWeight.Visibility = Visibility.Visible;
                FromWeight.Visibility = Visibility.Visible;
                CurrentMenu = OperationsUnit.Weight;
            }
            else if (input == OperationsUnit.Temperature.ToString())
            {
                NavigateMenu(sender, e);
                InitialForTemperature();
                Temperature.Visibility = Visibility.Visible;
                CurrentMenu = OperationsUnit.Temperature;
            }
        }

        private void Button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ShowDigits("=");
            e.Handled = true;
        }

        private void IntialForDecimal()
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
                    if (button.Tag.ToString() == "to")
                    {
                        button.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void IntialForPercent()
        {
            List<string> allowedButtons =
               new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "C", "AC", "=", ".", "to", "menu" };

            foreach (var child in mainGrid.Children)
            {
                var button = child as Button;

                if (button != null)
                {
                    if (!allowedButtons.Any(p => p == button.Tag.ToString()))
                    {
                        button.Visibility = Visibility.Collapsed;
                    }
                    if (button.Tag.ToString() == "to" ||
                        button.Tag.ToString() == "mode")
                    {
                        button.Visibility = Visibility.Visible;
                    }
                }

            }
        }

        private void IntialForWeight()
        {
            List<string> allowedButtons =
                 new List<string>
                {
                "1","2","3","4","5","6","7","8","9","0","C","AC","=","int","menu","weight","."
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
                    if (button.Tag.ToString() == "weight")
                    {
                        button.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void InitialForTemperature()
        {
            List<string> allowedButtons =
                 new List<string>
                {
                "1","2","3","4","5","6","7","8","9","0","C","AC","=","menu","weight","."
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
                    if (button.Tag.ToString() == "to")
                    {
                        button.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void ChangeToNumber(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = seletlist.SelectedIndex;

            if (selectedIndex == 0)
            {
                ConvertionMethod = NumberUnits.Binary;
            }
            else if (selectedIndex == 1)
            {
                ConvertionMethod = NumberUnits.HexaDecimal;
            }
            else if (selectedIndex == 2)
            {
                ConvertionMethod = NumberUnits.Octal;
            }
        }

        private void ChangeToDecimal(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = percentOrDecimal.SelectedIndex;

            if (selectedIndex == 0)
            {
                SelectPercent = PercentUnits.Percent;
            }
            else if (selectedIndex == 1)
            {
                SelectPercent = PercentUnits.Decimal;
            }
        }

        private void FromWeigthUnit(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = FromWeight.SelectedIndex;

            if (selectedIndex == 0)
            {
                FormMethod = WeightUnits.Milligrams;
            }
            else if (selectedIndex == 1)
            {
                FormMethod = WeightUnits.Grams;
            }
            else if (selectedIndex == 2)
            {
                FormMethod = WeightUnits.Kilograms;
            }
            else if (selectedIndex == 3)
            {
                FormMethod = WeightUnits.Ounces;
            }
            else if (selectedIndex == 4)
            {
                FormMethod = WeightUnits.Pounds;
            }
        }

        private void ToWeightUnit(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = ToWeight.SelectedIndex;

            if (selectedIndex == 0)
            {
                ToMethod = WeightUnits.Milligrams;
            }
            else if (selectedIndex == 1)
            {
                ToMethod = WeightUnits.Grams;
            }
            else if (selectedIndex == 2)
            {
                ToMethod = WeightUnits.Kilograms;
            }
            else if (selectedIndex == 3)
            {
                ToMethod = WeightUnits.Ounces;
            }
            else if (selectedIndex == 4)
            {
                ToMethod = WeightUnits.Pounds;
            }
        }

        private void ChangeTUnit(object sender, SelectionChangedEventArgs e)
        {
            var Tselected = Temperature.SelectedIndex;
            if (Tselected == 0)
            {
                SelectedTUnit = TemperatureUnits.Celsius;
            }
            else if (Tselected == 1)
            {
                SelectedTUnit = TemperatureUnits.Fahrenheit;
            }
        }
    }
}
