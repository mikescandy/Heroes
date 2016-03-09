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
            var rees = Current.Resources;
            System.Diagnostics.Debug.WriteLine("===============");
            var assembly = typeof(App).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
                System.Diagnostics.Debug.WriteLine("found resource: " + res);


            if (Device.OS != TargetPlatform.WinPhone)
            {
               // DependencyService.Get<ILocalize>().SetLocale();
                //Resx.AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }

            FreshIOC.Container.Register<IRepository, Repository>();

            MainPage = new NavigationPage(new LaunchPage(this));
        }

       

        public void LoadBasicNav()
        {
            var page = FreshPageModelResolver.ResolvePageModel<CharacterPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        //public void LoadMasterDetail()
        //{
        //    var masterDetailNav = new FreshMasterDetailNavigationContainer();
        //    masterDetailNav.Init("Menu", "Menu.png");
        //    masterDetailNav.AddPage<ContactListPageModel>("Contacts", null);
        //    masterDetailNav.AddPage<QuoteListPageModel>("Quotes", null);
        //    MainPage = masterDetailNav;
        //}

        public void LoadTabbedNav()
        {
            var tabbedNavigation = new FreshTabbedNavigationContainer();
       

            tabbedNavigation.AddTab<CharacterPageModel>("", "hero.png");
            tabbedNavigation.AddTab<EquipmentPageModel>("", "equipment.png");
            tabbedNavigation.AddTab<WeaponPageModel>("", "equipment.png");
            tabbedNavigation.AddTab<CharacterPageModel>("", "equipment.png");
            tabbedNavigation.AddTab<CharacterPageModel>("", "equipment.png");

            MainPage = tabbedNavigation;
        }

        //public void LoadCustomNav()
        //{
        //    MainPage = new CustomImplementedNav();
        //}

        //public void LoadMultipleNavigation()
        //{
        //    var masterDetailsMultiple = new MasterDetailPage(); //generic master detail page

        //    //we setup the first navigation container with ContactList
        //    var contactListPage = FreshPageModelResolver.ResolvePageModel<ContactListPageModel>();
        //    contactListPage.Title = "Contact List";
        //    //we setup the first navigation container with name MasterPageArea
        //    var masterPageArea = new FreshNavigationContainer(contactListPage, "MasterPageArea");
        //    masterPageArea.Title = "Menu";

        //    masterDetailsMultiple.Master = masterPageArea; //set the first navigation container to the Master

        //    //we setup the second navigation container with the QuoteList 
        //    var quoteListPage = FreshPageModelResolver.ResolvePageModel<QuoteListPageModel>();
        //    quoteListPage.Title = "Quote List";
        //    //we setup the second navigation container with name DetailPageArea
        //    var detailPageArea = new FreshNavigationContainer(quoteListPage, "DetailPageArea");

        //    masterDetailsMultiple.Detail = detailPageArea; //set the second navigation container to the Detail

        //    MainPage = masterDetailsMultiple;
        //}

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
