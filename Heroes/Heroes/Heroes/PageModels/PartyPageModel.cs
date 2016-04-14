using System;
using System.Collections.Generic;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;
using Core.Extensions;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public sealed class PartyPageModel : BaseListItemsPageModel
    {
        public int PartyId { get; set; }

        public Party Party { get; set; }

        public PartyPageModel (IRepository repository) : base (repository)
        {
        }

        public override void Init (object initData)
        {
            base.Init (initData);
            PartyId = (int)initData;
            Party = Repository.Get<Party> (PartyId);
            Title = Party.Name;
            SelectItem = new Command (async () => {
                switch (SelectedItem.ItemType) {
                case ItemType.Character:
                    await CoreMethods.PushPageModel<MainTabbedPageModel> (SelectedItem.ID);
                    break;
                case ItemType.None:
                    await CoreMethods.PushPageModel<AddCharacterPageModel> (PartyId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException ();
                }
            });

            Refresh ();
        }

        public override void ReverseInit (object returndData)
        {
            Refresh ();
            base.ReverseInit (returndData);
        }

        protected override void ViewIsAppearing (object sender, EventArgs e)
        {
            Refresh ();
            base.ViewIsAppearing (sender, e);
        }

        protected override List<ListItemViewModel> GetItems ()
        {
            var parties = Repository.GetAll<Character> (c => c.PartyId == PartyId);

            var items = App.Mapper.Map<List<ListItemViewModel>> (parties);

            items.Add (GetAddItem ());
            return items;
        }

        private void Refresh()
        {
            var items = GetItems ();
            Items = items.ToObservable ();
        }
    }
}