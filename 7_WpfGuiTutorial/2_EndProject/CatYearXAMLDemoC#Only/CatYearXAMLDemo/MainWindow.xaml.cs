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
        public TextBlock resultTextBlock;
        public TextBox inputCatAge;
        StackPanel MainVertivalStackPanel;
        public MainWindow()
        {

            InitializeComponent();
            Image backgroundImage = new Image() 
            {
                Source = new BitmapImage(
                new Uri(Environment.CurrentDirectory + @"\..\..\..\images\cat.jpg" , UriKind.RelativeOrAbsolute))
            };
            resultTextBlock = new TextBlock() { Text = "Your cat is ", FontSize = 18};
            inputCatAge = new TextBox()
            {
                Width = 120, TextAlignment = TextAlignment.Center,
                FontSize = 16, Margin = new Thickness(5, 0, 0, 0)
            };
            inputCatAge.KeyDown += inputCatAge_KeyDown;

            TextBlock userQuestion = new TextBlock() 
            {
                Text = "How old is your cat?" , FontSize = 18
            };

            StackPanel HorizontalSP = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(1,5,0,0)
            };
            HorizontalSP.Children.Add(userQuestion);
            HorizontalSP.Children.Add(inputCatAge);

            MainVertivalStackPanel = new StackPanel();
            MainVertivalStackPanel.Children.Add(HorizontalSP);
            MainVertivalStackPanel.Children.Add(resultTextBlock);
            MainVertivalStackPanel.Children.Add(backgroundImage);
            myMainWIndow.Content = MainVertivalStackPanel;

        }

        private void inputCatAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
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
                    else if (inputCatAgeInput >= 2 && inputCatAgeInput < 25)
                    {
                        resultHumanAge = (((inputCatAgeInput - 2) * 4) + 24).ToString();
                        resultTextBlock.Text = "Your cat is " + resultHumanAge + " years old";
                    }
                    else
                    {
                        resultTextBlock.Text = "You entered a value that is not between 0-25";
                    }
                    TextBlock myExtraText = new TextBlock()
                    {
                        Text = "Underneath the cat",
                        FontSize = 18
                    };
                    MainVertivalStackPanel.Children.Add(myExtraText);




                }
                catch (Exception myException)
                {
                    MessageBox.Show("Not a valid number, please enter a numeric value! \n" + myException.Message);
                }
            }
        }



    }
}
