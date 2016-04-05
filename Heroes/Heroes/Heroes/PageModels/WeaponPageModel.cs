using System.Collections.Generic;
using System.Collections.ObjectModel;
using FreshMvvm;
using Heroes;
using Heroes.Services;
using PropertyChanged;
using Core.Pages;

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
