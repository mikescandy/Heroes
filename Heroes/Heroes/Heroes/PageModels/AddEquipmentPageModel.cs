using System.Collections.Specialized;
using System.Linq;
using Core;
using Core.Pages;
using Heroes.Services;
using PropertyChanged;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class AddEquipmentPageModel : BasePageModel
    {
        public TrulyObservableCollection<EquipmentViewModel> AdventuringGears { get; set; }

        public EquipmentViewModel SelectedAdventuringGear { get; set; }

        public bool MultiSelect { get; set; }

        public double TotalCost
        { 
            get { 
                return AdventuringGears.Where (m => m.IsSelected).Sum (m => m.Cost); 
            }
        }

        public double TotalWeight
        { 
            get {
                return AdventuringGears.Where (m => m.IsSelected).Sum (m => m.Weight); 
            } 
        }

        private readonly IRepository repository;

        public AddEquipmentPageModel (IRepository repository)
        {
            this.repository = repository;
            var adventuringGears = this.repository.GetAllAdventuringGear ();
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