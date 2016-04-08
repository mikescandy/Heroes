using AutoMapper;
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
        public static IMapper Mapper { get; set; }

        public App ()
        {
            InitializeComponent ();
            FreshIOC.Container.Register<IRepository, Repository> ();
            FreshIOC.Container.Register<IValidator<EditCharacterPageModel>, CharacterValidator> ();
            var automapperConfiguration = new AutomapperConfig ();
            Mapper = automapperConfiguration.Mapper;
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