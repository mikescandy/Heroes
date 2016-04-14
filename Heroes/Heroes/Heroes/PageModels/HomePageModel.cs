using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Core.Extensions;
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
            Title = "Heroes";
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

            Refresh ();
        }

        public override void ReverseInit(object returndData)
        {
            Refresh ();
            base.ReverseInit (returndData);
        }

        protected override void ViewIsAppearing (object sender, EventArgs e)
        {
            Refresh ();
            base.ViewIsAppearing (sender, e);
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

        private void Refresh ()
        {
            var items = GetItems ();
            Items = items.ToObservable ();
        }
    }
}