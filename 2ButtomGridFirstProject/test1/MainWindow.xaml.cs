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

namespace test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Uri uri;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void butten_Click(object sender, RoutedEventArgs e)
        {
            if(HamidLabel.Content != "Hamid")
            {
                HamidLabel.Content = "Hamid";
                txtBox.Text = "Hamidam";
            }
            LabelLeft.Content = LabelLeft.Content + "\nHamid";
        }

        private void butten2_Click(object sender, RoutedEventArgs e)
        {
            if (HamidLabel.Content != "Faraz")
            {
                HamidLabel.Content = "Faraz";
                txtBox.Text = "Farazzzzzz";
            }
            LabelLeft.Content = LabelLeft.Content + "\nFaraz";
        }

        private void ClearButten_Click(object sender, RoutedEventArgs e)
        {
            LabelLeft.Content = "";
            MessageBox.Show("Cleared","HI Dude" );
        }

        private void PageOne_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Page1();
        }

        private void PageTwo_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new page2();
        }

        private void imageLoading_Click(object sender, RoutedEventArgs e)
        {
            // Create Image Element
            Image myImage = new Image();
            myImage.Width = 200;

            // Create source
            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage.BeginInit();
            uri = new Uri(@"E:\Nabz Group\C#\test1\test1\Images\Orginal_image.jpg");
            myBitmapImage.UriSource = uri;
            
            // To save significant application memory, set the DecodePixelWidth or
            // DecodePixelHeight of the BitmapImage value of the image source to the desired
            // height or width of the rendered image. If you don't do this, the application will
            // cache the image as though it were rendered as its normal size rather then just
            // the size that is displayed.
            // Note: In order to preserve aspect ratio, set DecodePixelWidth
            // or DecodePixelHeight but not both.
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            //set image source
            myImage.Source = myBitmapImage;
            

        }
        public void grayscale()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = uri;
            bitmap.EndInit();

            // Create a FormatConvertedBitmap  
            FormatConvertedBitmap grayBitmapSource = new FormatConvertedBitmap();

            // BitmapSource objects like FormatConvertedBitmap can only have their properties  
            // changed within a BeginInit/EndInit block.  
            grayBitmapSource.BeginInit();

            // Use the BitmapSource object defined above as the source for this new   
            // BitmapSource (chain the BitmapSource objects together).  
            grayBitmapSource.Source = bitmap;

            // Key of changing the bitmap format is DesitnationFormat property of BitmapSource.  
            // It is a type of PixelFormat. FixelFormat has dozens of options to set   
            // bitmap formatting.   
            grayBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            grayBitmapSource.EndInit();
            image1.Source = grayBitmapSource;
            // Create a new Image  
            //Image grayImage = new Image();
            //grayImage.Width = 300;
            //// Set Image source to new FormatConvertedBitmap  
            //grayImage.Source = grayBitmapSource;

            //// Add Image to Window  

        }
    }
}
