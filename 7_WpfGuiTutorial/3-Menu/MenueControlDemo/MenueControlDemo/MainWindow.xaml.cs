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

namespace MenueControlDemo
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New Project");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myTextBox.Text = "";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cBox = (ComboBox)sender;
            ComboBoxItem cbItem = (ComboBoxItem)cBox.SelectedItem;
            string newFontSize = (string) cbItem.Content;
            int temp;
            if (Int32.TryParse(newFontSize ,out temp))
            {
                if (myTextBox != null)
                {
                    myTextBox.FontSize = temp;
                }
            }
        }

        private void miBold_Checked(object sender, RoutedEventArgs e)
        {
            myTextBox.FontWeight = FontWeights.Bold;
        }

        private void miBold_Unchecked(object sender, RoutedEventArgs e)
        {
            myTextBox.FontWeight = FontWeights.Normal;
        }

        private void miItalic_Checked(object sender, RoutedEventArgs e)
        {
            myTextBox.FontStyle = FontStyles.Italic;
        }

        private void miItalic_Unchecked(object sender, RoutedEventArgs e)
        {
            myTextBox.FontStyle = FontStyles.Normal;
        }

        private void increaseSB_Click(object sender, RoutedEventArgs e)
        {
            if (mypb.Value >= 100)
            {
                status.Content = "Done";
            }
            else
            {
                mypb.Value += 10;
            }

        }
    }
}
