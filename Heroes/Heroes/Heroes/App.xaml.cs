﻿using AutoMapper;
using FluentValidation;
using FreshMvvm;
using Heroes.Mappings;
using Heroes.PageModels;
using Heroes.Pages;
using Heroes.Services;
using Heroes.Validators;
using Xamarin.Forms;

namespace Heroes
{
    public partial class App : Application
    {
        public static IMapper Mapper;

        public App ()
        {
            InitializeComponent ();
            FreshIOC.Container.Register<IRepository, Repository> ();
            //FreshIOC.Container.Register<IValidatorFactory, FluentValidatorFactory>();
            //FreshIOC.Container.Register<IValidationService, FluentValidationService>();
            FreshIOC.Container.Register<IValidator<EditCharacterPageModel>, CharacterValidator> ();
            var automapperConfiguration = new AutomapperConfig ();
            Mapper = automapperConfiguration.Mapper;
            //var masterDetailNav = new FreshMasterDetailNavigationContainer();
            //masterDetailNav.Init("Menu", "icon");
            //masterDetailNav.AddPage<CharacterPageModel>("Character");
            //masterDetailNav.AddPage<MainTabbedPageModel>("Main");

            //var md = new MasterDetailPage();
            //md.Master = FreshPageModelResolver.ResolvePageModel<MenuPageModel>();
            ////md.Detail = FreshPageModelResolver.ResolvePageModel<MainTabbedPageModel>();
            //    var t =new TabbedPage();
            //t.Children.Add(new ContentPage {Title = "A"});
            //t.Children.Add(new ContentPage {Title = "b"});

            //md.Detail = t;

            //MainPage = md;
            //FreshPageModelResolver.ResolvePageModel<MainTabbedPageModel>()

            MainPage = new RootPage ();
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}