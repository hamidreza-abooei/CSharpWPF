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


namespace BitmapTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("E:/NabzGroup/C%23/4BitmapTestingLoadingMatrix/BitmapTesting/BitmapTesting/background.jpg", UriKind.Absolute));
            simpleImage = image;
            //// Create source.
            //BitmapImage bi = new BitmapImage();
            //// BitmapImage.UriSource must be in a BeginInit/EndInit block.
            //bi.BeginInit();
            //bi.UriSource = new System.Uri("/newImage.png", UriKind.Relative);
            //bi.EndInit();
            //// Set the image source.
            //simpleImage.Source = bi;


        }

        }
    
}
