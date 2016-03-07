using System.Collections.Generic;
using System.Collections.ObjectModel;
using FreshMvvm;
using Heroes;
using Heroes.Services;
using PropertyChanged;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class EquipmentPageModel : FreshBasePageModel
    {
        private readonly IRepository _repository;
        public EquipmentPageModel(IRepository repository)
        {
            _repository = repository;
            
        }

        public override void Init(object initData)
        {
            AdventuringGears = new ObservableCollection<AdventuringGear>();
            AdventuringGears.Add(new AdventuringGear { Name = "test" });
        }

        public ObservableCollection<AdventuringGear> AdventuringGears { get; set; }

        public override void ReverseInit(object returndData)
        {
            var item = (AdventuringGear) returndData;
            AdventuringGears.Add(item);
            
            base.ReverseInit(returndData);
        }
    }
}
