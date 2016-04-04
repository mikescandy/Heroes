using System;

using Xamarin.Forms;
using PropertyChanged;
using Heroes.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace Heroes
{
	[ImplementPropertyChanged]
	public class HomePageModel : BasePageModel
	{
		private readonly IRepository _repository;

		public ObservableCollection<HomePageViewModel> Items {get; set;}

		public HomePageModel (IRepository repository)
		{
			_repository = repository;
		}

		public override void Init (object initData)
		{
			base.Init (initData);
			var parties = _repository.GetAll<Party> ();
			var characters = _repository.GetAllCharactersNotInParties ();
			var items = new List<HomePageViewModel> ();
			var items2 = new List<HomePageViewModel> ();
			App.Mapper.Map (parties, items);
			App.Mapper.Map (characters, items2);
			items =items.Union(items2).OrderByDescending (m => m.TimeStamp).ToList();
			items.Add (GetAddItem ());
			Items = new ObservableCollection<HomePageViewModel> (items);
		}

		private HomePageViewModel GetAddItem()
		{
			return new HomePageViewModel {
				Image="plus.png",
				IsAdd=true,
				IsReal=false,
				Name="Add new",
				ItemType=ItemType.None
			};
		}
	}
}


