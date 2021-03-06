﻿using System;
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

namespace Tsr.UI.Views
{
    /// <summary>
    /// Interaction logic for FiltersView.xaml
    /// </summary>
    public partial class FiltersView : UserControl
    {
        public FiltersViewModel Model
        {
            get
            {
                return (FiltersViewModel)DataContext;
            }
        }

        public FiltersView()
        {
            InitializeComponent();
        }

        private void PropertyGrid_PropertyValueChanged(object sender, Xceed.Wpf.Toolkit.PropertyGrid.PropertyValueChangedEventArgs e)
        {
            Model.OnPropertyValueChanged();
        }
    }
}
