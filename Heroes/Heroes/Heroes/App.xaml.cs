using System.Collections.Generic;
using System.Reflection;
using FreshMvvm;
using Heroes.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Heroes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            FreshIOC.Container.Register<IRepository, Repository>();

            var masterDetailNav = new FreshMasterDetailNavigationContainer();
            masterDetailNav.Init("Menu","icon");
            masterDetailNav.AddPage<CharacterPageModel>("Character");
            masterDetailNav.AddPage<MainTabbedPageModel>("Main");

            MainPage = masterDetailNav;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
