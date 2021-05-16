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

namespace _1_HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            rbTrump.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myLabel.Foreground = Brushes.Red;
            double myfontSize = myLabel.FontSize ;
            myLabel.FontSize = myfontSize *1.1;

        }

        private void myButten_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            myLabel.Foreground = Brushes.Blue;
            double myfontSize = myLabel.FontSize;
            myLabel.FontSize = myfontSize / 1.1;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            cbParent.IsChecked = null;
            if ((cbc.IsChecked == true) && (cbp.IsChecked == true) && (chh.IsChecked == true) && (chy.IsChecked == true))
            {
                cbParent.IsChecked = true;
            }
            if ((cbc.IsChecked == false) && (cbp.IsChecked == false) && (chh.IsChecked == false) && (chy.IsChecked == false))
            {
                cbParent.IsChecked = false;
            }
        }



        private void cbParent_Checked(object sender, RoutedEventArgs e)
        {

            bool newval = (cbParent.IsChecked == true);
            cbc.IsChecked = newval;
            cbp.IsChecked = newval;
            chh.IsChecked = newval;
            chy.IsChecked = newval;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            myImage.Source = new BitmapImage(new Uri(@"/1_HelloWorld;component/obama.jpg", UriKind.Relative));
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tbSlider != null)
            {
                tbSlider.Text = "Slider value is:  " + slider.Value.ToString();
                tbSlider.FontSize = slider.Value;
                
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            if (calendarTxt != null)
                calendarTxt.Text = (sender as DatePicker).SelectedDate.ToString();
        }
    }
}
