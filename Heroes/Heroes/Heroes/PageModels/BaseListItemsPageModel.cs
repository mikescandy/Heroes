using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Core.Pages;
using Heroes.Models;
using Heroes.PageModels;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public abstract class BaseListItemsPageModel : BasePageModel
    {
        protected readonly IRepository Repository;

        public ObservableCollection<ListItemViewModel> Items { get; set; }

        public ICommand SelectItem { get; set; }

        public ListItemViewModel SelectedItem { get; set; }

        protected BaseListItemsPageModel (IRepository repository)
        {
            Repository = repository;
        }

        public override void ReverseInit (object returndData)
        {
            var items = GetItems ();
            Items = new ObservableCollection<ListItemViewModel> (items);
        }

        protected abstract List<ListItemViewModel> GetItems ();

        protected ListItemViewModel GetAddItem ()
        {
            return new ListItemViewModel {
                Image = "plus.png",
                IsAdd = true,
                IsReal = false,
                Name = "Add new",
                ItemType = ItemType.None
            };
        }
    }
}