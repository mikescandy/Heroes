using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class PartyPageModel : BaseListItemsPageModel
    {
        public int PartyId { get; set; }

        public PartyPageModel(IRepository repository) : base(repository)
        {
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            PartyId = (int)initData;
            SelectItem = new Command(async () =>
            {
                switch (SelectedItem.ItemType)
                {
                    case ItemType.Party:
                        break;
                    case ItemType.None:
                        await CoreMethods.PushPageModel<AddCharacterPageModel>(PartyId);
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
            var parties = Repository.GetAll<Character>(c => c.PartyId == PartyId);

            var items = App.Mapper.Map<List<ListItemViewModel>>(parties);

            items.Add(GetAddItem());
            return items;
        }
    }
}