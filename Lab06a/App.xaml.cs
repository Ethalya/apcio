using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lab06a.Services;
using Lab06a.Views;

namespace Lab06a
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<StudentsDataStore>();
            MainPage = new MainPage();
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
