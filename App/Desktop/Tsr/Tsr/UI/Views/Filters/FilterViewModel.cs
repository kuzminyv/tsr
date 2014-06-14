using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Tsr.Imaging;
using Tsr.UI.Commands;
using Tsr.UI.Common.Mvvm;

namespace Tsr.UI.Views
{
    public class FilterViewModel : ViewModel
    {
        private readonly IFilter _model;

        public string Name
        {
            get
            {
                return _model.GetType().Name;
            }
        }

        public object Options
        {
            get
            {
                return _model.OptionsObject;
            }
        }

        private readonly FiltersViewModel _filtersVM;
        public FiltersViewModel FiltersVM
        {
            get
            {
                return _filtersVM;
            }
        }

        private readonly ICommand _applyFilterCommand;
        public ICommand ApplyFilterCommand
        {
            get
            {
                return _applyFilterCommand;
            }
        }

        public FilterViewModel(IFilter model, FiltersViewModel filtersVM)
        {
            _model = model;
            _filtersVM = filtersVM;
            _applyFilterCommand = new DelegateCommand(ApplyFilter);
        }

        public void ApplyFilter()
        {
            RawImage image = RawImage.FromBitmap((BitmapImage)FiltersVM.MainVM.SourceImage);
            _model.ApplyFilter(image);
            FiltersVM.MainVM.ResultImage = image.GetBitmap();
        }
    }
}
