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

namespace CatYearXAMLDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void inputCatAge_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {
                    int inputCatAgeInput = Int32.Parse(inputCatAge.Text);
                    string resultHumanAge = "";
                    if (inputCatAgeInput >= 0 && inputCatAgeInput <= 1)
                    {
                        resultHumanAge = "0-15";
                        resultTextBlock.Text = "Your cat is " + resultHumanAge + " years old";

                    }
                    else if(inputCatAgeInput >= 2 && inputCatAgeInput < 25)
                    {
                        resultHumanAge = (((inputCatAgeInput - 2) * 4) + 24).ToString();
                        resultTextBlock.Text = "Your cat is " + resultHumanAge + " years old";
                    }
                    else
                    {
                        resultTextBlock.Text = "You entered a value that is not between 0-25";
                    }

                    

                }
                catch (Exception myException)
                {
                    MessageBox.Show("Not a valid number, please enter a numeric value! \n" + myException.Message);
                }
            }
        }
    }
}
