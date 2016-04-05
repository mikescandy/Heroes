using System;

using Xamarin.Forms;
using PropertyChanged;
using Heroes.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class HomePageModel : BasePageModel
    {
        private readonly IRepository _repository;

        public ObservableCollection<HomePageViewModel> Items { get; set; }

        public Command<HomePageViewModel> SelectItem { protected set; get; }

        public HomePageModel(IRepository repository)
        {
            _repository = repository;

            SelectItem = new Command<HomePageViewModel>(async (item) =>
              {
                  switch (item.ItemType)
                  {
                      case ItemType.Party:
                          break;
                      case ItemType.Character:
                          await CoreMethods.PushPageModel<CharacterPageModel>(item);
                          break;
                      case ItemType.None:
                          break;
                      default:
                          throw new ArgumentOutOfRangeException();
                  }
              });
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            var parties = _repository.GetAll<Party>();
            var characters = _repository.GetAllCharactersNotInParties();
            var items = App.Mapper.Map<List<HomePageViewModel>>(parties);
            var items2 = App.Mapper.Map<List<HomePageViewModel>>(characters);
            items = items.Union(items2).OrderByDescending(m => m.TimeStamp).ToList();
            items.Add(GetAddItem());
            Items = new ObservableCollection<HomePageViewModel>(items);
        }

        private HomePageViewModel GetAddItem()
        {
            return new HomePageViewModel
            {
                Image = "plus.png",
                IsAdd = true,
                IsReal = false,
                Name = "Add new",
                ItemType = ItemType.None
            };
        }
    }
}


