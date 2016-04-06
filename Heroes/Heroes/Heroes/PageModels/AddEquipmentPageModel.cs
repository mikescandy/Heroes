using System.Collections.Specialized;
using System.Linq;
using Core;
using Heroes.Services;
using PropertyChanged;
using Core.Pages;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class AddEquipmentPageModel : BasePageModel
    {
        public TrulyObservableCollection<EquipmentViewModel> AdventuringGears { get; set; }

        public EquipmentViewModel SelectedAdventuringGear { get; set; }

        public bool MultiSelect { get; set; }

        public double TotalCost { get { return AdventuringGears.Where (m => m.IsSelected).Sum (m => m.Cost); } }

        public double TotalWeight { get { return AdventuringGears.Where (m => m.IsSelected).Sum (m => m.Weight); } }

        private readonly IRepository _repository;

        public AddEquipmentPageModel (IRepository repository)
        {
            _repository = repository;
            var adventuringGears = _repository.GetAllAdventuringGear ();
            AdventuringGears = new TrulyObservableCollection<EquipmentViewModel> (adventuringGears.Select (m => new EquipmentViewModel (m)).ToList ());
            AdventuringGears.CollectionChanged += AdventuringGearsOnCollectionChanged;
        }

        private void AdventuringGearsOnCollectionChanged (object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            RaisePropertyChanged ("TotalCost");
            RaisePropertyChanged ("TotalWeight");
        }
    }
}
