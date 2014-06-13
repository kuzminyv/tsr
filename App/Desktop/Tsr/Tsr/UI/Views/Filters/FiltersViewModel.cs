using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsr.Imaging;
using Tsr.Imaging.Filters;
using Tsr.UI.Common.Mvvm;

namespace Tsr.UI.Views
{
    public class FiltersViewModel : ViewModel
    {
        private ObservableCollection<FilterViewModel> _filters;
        public ObservableCollection<FilterViewModel> Filters
        {
            get
            {
                if (_filters == null)
                {
                    _filters = new ObservableCollection<FilterViewModel>() 
                    { 
                        new FilterViewModel(new DerivFilter(), this),
                        new FilterViewModel(new MainColorFilter(), this)
                    };
                }
                return _filters;
            }
        }

        private readonly MainViewModel _mainVM;
        public MainViewModel MainVM
        {
            get
            {
                return _mainVM;
            }
        }

        public FiltersViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
        }
    }
}
