using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Pages;
using Heroes.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public sealed class MenuPageModel : BasePageModel
    {
        public ObservableCollection<HomeMenuItem> MenuItems { get; set; }

        public HomeMenuItem SelectedHomeMenuItem { get; set; }

        public MenuPageModel()
        {
            Title = "Menu";
            Image = string.Empty;
            MenuItems = new ObservableCollection<HomeMenuItem>(new List<HomeMenuItem> {
                new HomeMenuItem { Icon = string.Empty, Title = "Home", TargetViewModel = typeof(HomePageModel) },
                new HomeMenuItem { Icon = string.Empty, Title = "Character", TargetViewModel = typeof(CharacterPageModel) }
            });
        }

        public Command NavigateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel(SelectedHomeMenuItem.TargetViewModel);
                });
            }
        }
    }
}