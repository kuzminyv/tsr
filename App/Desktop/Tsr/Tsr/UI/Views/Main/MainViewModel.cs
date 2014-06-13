using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tsr.UI.Common.Mvvm;

namespace Tsr.UI.Views
{
    public class MainViewModel : BaseWindowModel
    {
        private string _sourceImagePath;
        private string SourceImagePath
        {
            get
            {
                return _sourceImagePath;
            }
            set
            {
                if (_sourceImagePath != value)
                {
                    SourceImage = LoadImage(value);
                    _sourceImagePath = value;
                    OnPropertyChanged("SourceImagePath");
                }
            }
        }

        private ImageSource _sourceImage;
        public ImageSource SourceImage
        {
            get
            {
                return _sourceImage;
            }
            private set
            {
                if (_sourceImage != value)
                {
                    _sourceImage = value;
                    OnPropertyChanged("SourceImage");
                }
            }
        }

        private ImageSource _resultImage;
        public ImageSource ResultImage
        {
            get
            {
                return _resultImage;
            }
            set
            {
                if (_resultImage != value)
                {
                    _resultImage = value;
                    OnPropertyChanged("ResultImage");
                }
            }
        }

        private FiltersViewModel _filtersVM;
        public FiltersViewModel FiltersVM
        {
            get
            {
                return _filtersVM;
            }
        }

        public ImageSource LoadImage(string path)
        {
            if (File.Exists(path))
            {
                Uri uri = new Uri(path);
                return new BitmapImage(uri);
            }
            return null;
        }

        public MainViewModel()
        {
            _filtersVM = new FiltersViewModel(this);
            SourceImagePath = @"C:\Users\yura\Google Диск\Project\TSR\TsrImages\Images9049\00000005.png";
        }
    }
}
