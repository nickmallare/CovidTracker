using System;
using System.Collections.Generic;
using CovidTracker.TotalData.ViewModel;
using Xamarin.Forms;

namespace CovidTracker.TotalData.View
{
    public partial class TotalDataView : ContentPage
    {
        public TotalDataView()
        {
            InitializeComponent();
            this.BindingContext = new TotalDataViewModel();
        }
    }
}
