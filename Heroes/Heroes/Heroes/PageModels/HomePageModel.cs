using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Core.Navigation;
using Core.Pages;
using Heroes.Models;
using Heroes.PageModels;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class HomePageModel : BasePageModel
    {
        private readonly IRepository repository;

        public ObservableCollection<HomePageViewModel> Items { get; set; }

        public ICommand SelectItem { get; set; }

        public HomePageViewModel SelectedItem { get; set; }

        public HomePageModel (IRepository repository)
        {
            this.repository = repository;
        }

        public override void Init (object initData)
        {
            base.Init (initData);
            SelectItem = new Command (async () => {
                switch (SelectedItem.ItemType)
                {
                case ItemType.Party:
                    break;
                case ItemType.Character:
                    await CoreMethods.PushPageModel<MainTabbedPageModel> (SelectedItem.ID);
                    break;
                case ItemType.None:
                    await CoreMethods.PushPageModel<ChoosePartyCharacterPageModel> (null, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException ();
                }
            });
            
            var items = GetHomePageItems ();
            Items = new ObservableCollection<HomePageViewModel> (items);
        }

        public override async void ReverseInit (object returndData)
        {
            var items = GetHomePageItems ();
            Items = new ObservableCollection<HomePageViewModel> (items);

            var navigationObject = (NavigationObject)returndData;
            if (navigationObject.DestinationViewModel != null)
            {
                await CoreMethods.PushPageModel (navigationObject.DestinationViewModel, navigationObject.PayLoad, navigationObject.Modal);
            }
        }

        private List<HomePageViewModel> GetHomePageItems ()
        {
            var parties = repository.GetAll<Party> ();
            var characters = repository.GetAllCharactersNotInParties ();

            var items = App.Mapper.Map<List<HomePageViewModel>> (parties);
            var items2 = App.Mapper.Map<List<HomePageViewModel>> (characters);

            items = items.Union (items2).OrderByDescending (m => m.TimeStamp).ToList ();
            items.Add (GetAddItem ());
            return items;
        }

        private HomePageViewModel GetAddItem ()
        {
            return new HomePageViewModel {
                Image = "plus.png",
                IsAdd = true,
                IsReal = false,
                Name = "Add new",
                ItemType = ItemType.None
            };
        }
    }
}