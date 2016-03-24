using System.Collections.Generic;
using FreshMvvm;
using Heroes;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class AddWeaponPageModel : BasePageModel
    {
        private readonly IRepository _repository;
        public AddWeaponPageModel(IRepository repository)
        {
            _repository = repository;
            Weapons = _repository.GetAllWeapons();

        }
        public List<Weapon> Weapons { get; set; }

        public Weapon SelectedWeapon { get; set; }
    }
}
