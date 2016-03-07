using System.Collections.Generic;
using FreshMvvm;
using Heroes.Models;
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

        public List<AdventuringGear> AdventuringGears { get; set; }

        public override void ReverseInit(object returndData)
        {
            base.ReverseInit(returndData);
        }
    }
}
