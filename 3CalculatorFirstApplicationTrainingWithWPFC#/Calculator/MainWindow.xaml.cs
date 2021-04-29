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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string resText = "";
        private float first_number = 0;
        private float second_number = 0;
        private string operation = "";



        public MainWindow()
        {
            InitializeComponent();
        }
        private void operationUpdate(string operation)
        {
            resText = resText + operation;
            res_box.Text = resText;
            this.operation = operation;
        }
        public void numberUpdate (int number)
        {
            resText = resText + number.ToString();
            res_box.Text = resText;
            if (operation.Equals(""))
            {
                first_number = first_number * 10 + number;
            }else
            {
                second_number = second_number * 10 + number;
            }    
        }
        public void result()
        {
            float res = 0;
            if (operation == "")
            {
                res = first_number;
            }
            else if(operation == "+")
            {
                res = first_number + second_number;
            }
            else if (operation == "-")
            {
                res = first_number - second_number;
            }
            else if (operation == "*")
            {
                res = first_number * second_number;
            }
            else if (operation == "/")
            {
                res = first_number / second_number;
            }
            else if (operation == "^")
            {
                res = (float) Math.Pow(first_number, second_number);
            }
            res_box.Text = res_box.Text + "\n= " + res.ToString();
            listBox.Items.Add(res.ToString());



        }
        public void delButten_Click(object sender, RoutedEventArgs e)
        {
            //char poped;
            //int length_of = restext.length;
            //if (length_of > 0)
            //{
            //    poped = restext[length_of - 1];
            //    restext = restext.remove(length_of - 1, 1);
            //    res_box.text = restext;
            //}
            first_number = 0;
            second_number = 0;
            operation = "";
            resText = "";
            res_box.Text = "0";
        }

        private void powButten_Click(object sender, RoutedEventArgs e)
        {
            operationUpdate("^");
        }


        private void divideButten_Click(object sender, RoutedEventArgs e)
        {
            operationUpdate("/");
            
        }

        private void sevenButten_Click(object sender, RoutedEventArgs e)
        {
            numberUpdate(7);
        }

        private void eightButten_Click(object sender, RoutedEventArgs e)
        {
            numberUpdate(8);
        }

        private void NineButten_Click(object sender, RoutedEventArgs e)
        {
            numberUpdate(9);
        }

        private void negativeButten_Click(object sender, RoutedEventArgs e)
        {
            operationUpdate("-");
        }

        private void mulButten_Click(object sender, RoutedEventArgs e)
        {
            operationUpdate("*");
        }

        private void fourButten_Click(object sender, RoutedEventArgs e)
        {
            numberUpdate(4);
        }

        private void fiveButten_Click(object sender, RoutedEventArgs e)
        {
            numberUpdate(5);
        }

        private void sixButten_Click(object sender, RoutedEventArgs e)
        {
            numberUpdate(6);
        }

        private void oneButten_Click(object sender, RoutedEventArgs e)
        {
            numberUpdate(1);
        }

        private void twoButten_Click(object sender, RoutedEventArgs e)
        {
            numberUpdate(2);
        }

        private void ThreeButten_Click(object sender, RoutedEventArgs e)
        {
            numberUpdate(3);
        }

        private void plusButten_Click(object sender, RoutedEventArgs e)
        {
            operationUpdate("+");
        }

        //private void percentButten_Click(object sender, RoutedEventArgs e)
        //{
            
        //}

        private void zeroButten_Click(object sender, RoutedEventArgs e)
        {
            numberUpdate(0);
        }

        //private void dotButten_Click(object sender, RoutedEventArgs e)
        //{
        //    resText = resText + ".";
        //    res_box.Text = resText;
        //}

        private void equalButten_Click(object sender, RoutedEventArgs e)
        {
            result();
        }

        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            WhiteTheme.IsChecked = false;

        }

        private void WhiteTheme_Click(object sender, RoutedEventArgs e)
        {
            DarkTheme.IsChecked = false;

        }

        private void sevenButten_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        {

        }




        //private void zeroButten_KeyDown(object sender, KeyEventArgs e)
        //{
        //    res_box.Text = e.Key.ToString();
        //}
    }
}
