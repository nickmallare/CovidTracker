﻿using System;
using CovidTracker.MenuMain.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MenuMainView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
