using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Core.Pages;
using Heroes;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class EquipmentPageModel : BasePageModel
    {
        public double TotalWeight
        { 
            get { 
                return AdventuringGears.Sum (m => m.Weight);
            } 
        }

        private readonly IRepository repository;

        public EquipmentPageModel (IRepository repository)
        {
            this.repository = repository;
        }

        public override void Init (object initData)
        {
            AdventuringGears = new ObservableCollection<AdventuringGear> ();
            AdventuringGears.CollectionChanged += AdventuringGearsOnCollectionChanged;
        }

        public ObservableCollection<AdventuringGear> AdventuringGears { get; set; }

        public override void ReverseInit (object returndData)
        {
            var item = returndData as EquipmentViewModel;
            if (item != null)
            {
                AdventuringGears.Add (repository.Get<AdventuringGear> (item.ID));
            }
            else
            {
                var items = returndData as List<EquipmentViewModel>;

                if (items != null)
                {
                    var gears = repository.GetMany<AdventuringGear> (items.Select (m => m.ID).ToList ());
                    foreach (var adventuringGear in gears)
                    {
                        AdventuringGears.Add (adventuringGear);
                    }
                }
            }

            base.ReverseInit (returndData);
        }

        private void AdventuringGearsOnCollectionChanged (object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            RaisePropertyChanged ("TotalWeight");
        }
    }
}