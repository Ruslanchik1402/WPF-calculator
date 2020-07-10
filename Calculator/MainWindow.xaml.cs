using System;
using System.Collections.Generic;
using System.Globalization;
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


namespace Calculator
{

    public partial class MainWindow : Window
    {
        double firstNumber, secondNumber, resultNumber; /// первое число, второе число, результат
        /// </summary>
        bool calcDone = false; //булевая переменная для отслеживания проведена ли операция или нет
        Operations operation = Operations.None;
        string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;//десятичный разделитель для чисел

        public MainWindow()
        {
            InitializeComponent();
            dec.Content = separator;
        }

       //операции
        private enum Operations
        {
            None,
            Division,
            Multiplication,
            Subtraction,
            Sum
        }

     
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (calcDone) 
            {
                result.Content = button.Content;
                calcDone = false;
            }
            else 
            {
                if (result.Content.ToString() == "0")
                {
                    result.Content = button.Content;
                }
                else
                {
                    result.Content = $"{result.Content}{button.Content}";
                }
            }

        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Content.ToString())
            {
                case "C":
                    result.Content = "0";
                    break;
                case "+/-":
                    if (!(result.Content.ToString() == "0"))
                    {
                        result.Content = Convert.ToDouble(result.Content) * -1;
                    }
                    break;

                case "/":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Division;
                    result.Content = "0";
                    break;
                case "*":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Multiplication;
                    result.Content = "0";
                    break;
                case "-":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Subtraction;
                    result.Content = "0";
                    break;
                case "+":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Sum;
                    result.Content = "0";
                    break;
                case "=":
                    switch (operation)
                    {
                        case Operations.Division:
                            if (calcDone)
                            {
                                if (!(result.Content.ToString() == "ERROR"))
                                {
                                    result.Content = Convert.ToDouble(result.Content) / secondNumber;
                                }
                            }
                            else
                            {
                                if (result.Content.ToString() == "0")
                                {
                                    result.Content = "ERROR";
                                    calcDone = true;
                                }
                                else
                                {
                                    secondNumber = Convert.ToDouble(result.Content);
                                    resultNumber = firstNumber / secondNumber;
                                    result.Content = resultNumber;
                                    calcDone = true;
                                }
                            }
                            break;
                        case Operations.Multiplication:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) * secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                resultNumber = firstNumber * secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                        case Operations.Subtraction:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) - secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                resultNumber = firstNumber - secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                        case Operations.Sum:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) + secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                resultNumber = firstNumber + secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                    }
                    break;
                default:
                    if (!result.Content.ToString().Contains(separator))
                    {
                        result.Content = $"{result.Content}{button.Content}";
                    }
                    break;
            }
        }
    }
}
