using System;
using System.Collections.Generic;
using System.IO;
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
using Tsr.Imaging;
using Tsr.UI.Common.Mvvm;
using Tsr.UI.Views;

namespace Tsr
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : BaseWindow
    {
        public MainView()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadImage(@"C:\Users\yura\Google Диск\Project\TSR\TsrImages\Images9049\00000005.png");
            //ApplyFilter();
        }

        //private void LoadImage(string fileName)
        //{
        //    if (File.Exists(fileName))
        //    {
        //        Uri uri = new Uri(fileName);
        //        BitmapImage bitmap = new BitmapImage(uri);
        //        imgSource.Source = bitmap;
        //    }
        //}

        //private void ApplyFilter()
        //{
        //    RawImage image = RawImage.FromBitmap((BitmapImage)imgSource.Source);
        //    new DerivFilter().ApplyFilter(image);
        //    imgResult.Source = image.GetBitmap();
        //}
    }
}
