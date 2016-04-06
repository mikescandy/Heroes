using System.Collections.ObjectModel;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class WeaponPageModel : BasePageModel
    {
        private readonly IRepository _repository;

        public WeaponPageModel (IRepository repository)
        {
            _repository = repository;
            
        }

        public override void Init (object initData)
        {
            Weapons = new ObservableCollection<Weapon> ();
        }

        public ObservableCollection<Weapon> Weapons { get; set; }

        public override void ReverseInit (object returndData)
        {
            var item = (Weapon)returndData;
            Weapons.Add (item);
            
            base.ReverseInit (returndData);
        }
    }
}
