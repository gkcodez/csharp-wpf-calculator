using csharp_wpf_calculator.Controllers;
using csharp_wpf_calculator.Enums;
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

namespace csharp_wpf_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        Operations selectedOperation;

        public MainWindow()
        {
            InitializeComponent();
            ResultLabel.Content = "10";
            ACButton.Click += ACButton_Click;
            NegativeButton.Click += NegativeButton_Click;
            PercentageButton.Click += PercentageButton_Click;
            EqualsButton.Click += EqualsButton_Click;
            DecimalButton.Click += DecimalButton_Click;
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ResultLabel.Content.ToString().Contains("."))
            {
                ResultLabel.Content += ".";
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                if (newNumber == 0)
                {
                    MessageBox.Show("Cannot Divide by Zero!", "Invalid Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (selectedOperation)
                    {
                        case Operations.Addition:
                            result = MathController.Add(lastNumber, newNumber);
                            break;
                        case Operations.Subtraction:
                            result = MathController.Subtract(lastNumber, newNumber);
                            break;
                        case Operations.Multiplication:
                            result = MathController.Multiply(lastNumber, newNumber);
                            break;
                        case Operations.Division:
                            result = MathController.Divide(lastNumber, newNumber);
                            break;
                    }
                }

                ResultLabel.Content = result;
                OldResultLabel.Content = "0";

            }

        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {                
            double tempNumber;

            if (double.TryParse(ResultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = tempNumber / 100;
                if (lastNumber != 0)
                {
                    tempNumber *= lastNumber;

                }
                ResultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                ResultLabel.Content = lastNumber.ToString();
            }
        }

        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                OldResultLabel.Content = ResultLabel.Content;
                ResultLabel.Content = "0";
            }

            if (sender == AddButton)
            {
                selectedOperation = Operations.Addition;
            }

            if (sender == SubtractButton)
            {
                selectedOperation = Operations.Subtraction;
            }

            if (sender == MultiplyButton)
            {
                selectedOperation = Operations.Multiplication;
            }

            if (sender == DivideButton)
            {
                selectedOperation = Operations.Division;
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int number = int.Parse((sender as Button).Content.ToString());

            if (ResultLabel.Content.Equals("0"))
            {
                ResultLabel.Content = number.ToString();
            }
            else
            {
                ResultLabel.Content += number.ToString();
            }
        }
    }
}
