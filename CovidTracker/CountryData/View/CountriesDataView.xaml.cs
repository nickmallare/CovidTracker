using System;
using System.Collections.Generic;
using CovidTracker.CountryData.ViewModel;
using Xamarin.Forms;

namespace CovidTracker.CountryData.View
{
    public partial class CountriesDataView : ContentPage
    {
        public CountriesDataView()
        {
            InitializeComponent();
            this.BindingContext = new CountriesDataViewModel();
        }
    }
}
