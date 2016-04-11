using System;
using PropertyChanged;
using Core.Pages;
using Heroes.Services;
using Xamarin.Forms;
using Heroes.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class PartyPageModel : BaseListItemsPageModel
    {
        public PartyPageModel (IRepository repository) : base (repository)
        {
        }

        public override void Init (object initData)
        {
            base.Init (initData);
            SelectItem = new Command (async () => {
                switch (SelectedItem.ItemType)
                {
                case ItemType.Party:
                    break;
                case ItemType.None:
                    await CoreMethods.PushPageModel<ChoosePartyCharacterPageModel> ();
                    break;
                default:
                    throw new ArgumentOutOfRangeException ();
                }
            });

            var items = GetItems ();
            Items = new ObservableCollection<ListItemViewModel> (items);
        }

        protected override System.Collections.Generic.List<ListItemViewModel> GetItems ()
        {
            var parties = Repository.GetAll<Party> ();

            var items = App.Mapper.Map<List<ListItemViewModel>> (parties);

            items.Add (GetAddItem ());
            return items;
        }
    }
}

