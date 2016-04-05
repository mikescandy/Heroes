using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes.Models;
using PropertyChanged;
using Xamarin.Forms;
using Core.Pages;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class MenuPageModel : BasePageModel
    {
        public ObservableCollection<HomeMenuItem> MenuItems { get; set; }

        public HomeMenuItem SelectedHomeMenuItem { get; set; }

        public MenuPageModel ()
        {
            Title = "Menu";
            Image = "";
            MenuItems = new ObservableCollection<HomeMenuItem> (new List<HomeMenuItem> {
                new HomeMenuItem { Icon = "", Title = "Home", TargetViewModel = typeof(HomePageModel) },
                new HomeMenuItem { Icon = "", Title = "Character", TargetViewModel = typeof(CharacterPageModel) },
            });
        }

        public Command NavigateCommand
        {
            get {
                return new Command (async () => {
                    await CoreMethods.PushPageModel (SelectedHomeMenuItem.TargetViewModel);
                });
            }
        }
    }
}
