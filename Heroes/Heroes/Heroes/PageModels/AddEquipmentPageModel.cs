using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Core;
using Core.Pages;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class AddEquipmentPageModel : BasePageModel
    {
        public TrulyObservableCollection<EquipmentViewModel> AdventuringGears { get; set; }

        public EquipmentViewModel SelectedAdventuringGear { get; set; }

        public ICommand OkCommand { get; set; }

        public ICommand MultiSelectCommand { get; set; }

        public bool MultiSelect { get; set; }

        public double TotalCost
        {
            get
            {
                return AdventuringGears.Where(m => m.IsSelected).Sum(m => m.Cost);
            }
        }

        public double TotalWeight
        {
            get
            {
                return AdventuringGears.Where(m => m.IsSelected).Sum(m => m.Weight);
            }
        }

        private readonly IRepository repository;

        public AddEquipmentPageModel(IRepository repository)
        {
            this.repository = repository;
        }
        
        public override void Init(object initData)
        {
            base.Init(initData);
            var adventuringGears = this.repository.GetAllAdventuringGear();
            AdventuringGears = new TrulyObservableCollection<EquipmentViewModel>(adventuringGears.Select(m => new EquipmentViewModel(m)).ToList());
            AdventuringGears.CollectionChanged += AdventuringGearsOnCollectionChanged;

            OkCommand = new Command(async () =>
            {
                object result;
                result = MultiSelect
                            ? (object)AdventuringGears.Where(m => m.IsSelected).ToList()
                            : SelectedAdventuringGear;
                await CoreMethods.PopPageModel(result, true); // Pushes a Modal
            });

            MultiSelectCommand = new Command(() =>
            {
                MultiSelect = !MultiSelect;
                foreach (var equipmentViewModel in AdventuringGears)
                {
                    equipmentViewModel.CheckboxVisible = MultiSelect;
                }
            });
        }

        private void AdventuringGearsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            RaisePropertyChanged("TotalCost");
            RaisePropertyChanged("TotalWeight");
        }
    }
}