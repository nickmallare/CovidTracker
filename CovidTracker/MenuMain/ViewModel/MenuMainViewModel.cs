using System;
using System.Windows.Input;
using CovidTracker.Common;
using CovidTracker.CountryData.View;
using CovidTracker.TotalData.View;
using Xamarin.Forms;

namespace CovidTracker.MenuMain.ViewModel
{
    public class MenuMainViewModel : BaseVM
    {
        

        public ICommand TotalCommand { private set; get; }
        public ICommand StateCommand { private set; get; }

        public MenuMainViewModel()
        {

            TotalCommand = new Command(
            execute: () =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new TotalDataView());
            },
            canExecute: () =>
            {
                return true;
            });

            StateCommand = new Command(
            execute: () =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new CountriesDataView());

            },
            canExecute: () =>
            {
                return true;
            });

        }
    }
}
