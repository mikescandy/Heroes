using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class HomePageModel : BaseListItemsPageModel
    {
        public HomePageModel(IRepository repository) : base(repository)
        {
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            SelectItem = new Command(async () =>
            {
                switch (SelectedItem.ItemType)
                {
                    case ItemType.Party:
                        await CoreMethods.PushPageModel<PartyPageModel>(SelectedItem.ID);
                        break;
                    case ItemType.Character:
                        await CoreMethods.PushPageModel<MainTabbedPageModel>(SelectedItem.ID);
                        break;
                    case ItemType.None:
                        await CoreMethods.PushPageModel<ChoosePartyCharacterPageModel>();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });

            var items = GetItems();
            Items = new ObservableCollection<ListItemViewModel>(items);
        }

        public override void ReverseInit(object returndData)
        {
            var items = GetItems();
            Items = new ObservableCollection<ListItemViewModel>(items);
        }

        protected override List<ListItemViewModel> GetItems()
        {
            var parties = Repository.GetAll<Party>();
            var characters = Repository.GetAllCharactersNotInParties();

            var items = App.Mapper.Map<List<ListItemViewModel>>(parties);
            var items2 = App.Mapper.Map<List<ListItemViewModel>>(characters);

            items = items.Union(items2).OrderByDescending(m => m.TimeStamp).ToList();
            items.Add(GetAddItem());
            return items;
        }
    }
}