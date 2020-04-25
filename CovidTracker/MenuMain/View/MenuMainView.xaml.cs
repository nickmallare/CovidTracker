using System;
using System.Collections.Generic;
using CovidTracker.MenuMain.ViewModel;
using Xamarin.Forms;

namespace CovidTracker.MenuMain.View
{
    public partial class MenuMainView : ContentPage
    {
        public MenuMainView()
        {
            InitializeComponent();
            this.BindingContext = new MenuMainViewModel();
            //
        }

        void ButtonTest_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
