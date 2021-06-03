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

namespace WpfBasics
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

        private void Applybutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The description is: {this.DescriptionText.Text}" );
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.WeldChB.IsChecked = this.FoldChB.IsChecked 
                = this.AssemblyChB.IsChecked = this.DrillChB.IsChecked 
                = this.LaserChB.IsChecked = this.LateeChB.IsChecked
                = this.PlasmaChB.IsChecked = this.PurchaseChB.IsChecked
                = this.RollChB.IsChecked = this.SawChB.IsChecked = false;
        }

        private void ChB_Checked(object sender, RoutedEventArgs e)
        {
            this.LengthText.Text += (string) ((CheckBox)sender).Content;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.NoteText == null)
                return;
            var combo = (ComboBox)sender;
            var value = (ComboBoxItem)combo.SelectedValue;
            this.NoteText.Text =value.Content.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_SelectionChanged(this.FinishDD,null);
        }

        private void SupplierNameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.MassText.Text = this.SupplierNameText.Text;
        }
    }
}
