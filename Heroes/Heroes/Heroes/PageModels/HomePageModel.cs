using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;
using Heroes.PageModels;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class HomePageModel : BasePageModel
    {
        private readonly IRepository _repository;

        public ObservableCollection<HomePageViewModel> Items { get; set; }

        public ICommand SelectItem { set; get; }

        public HomePageViewModel SelectedItem {	get; set; }

        public HomePageModel (IRepository repository)
        {
            _repository = repository;
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
                    await CoreMethods.PushPageModel<AddCharacterPageModel> (SelectedItem.ID, true);
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

            try
            {
                var id = (int)returndData;
                await CoreMethods.PushPageModel<MainTabbedPageModel> (id);
            }
            catch (Exception ex)
            {
                
            }
        }

        private List<HomePageViewModel> GetHomePageItems ()
        {
            var parties = _repository.GetAll<Party> ();
            var characters = _repository.GetAllCharactersNotInParties ();

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