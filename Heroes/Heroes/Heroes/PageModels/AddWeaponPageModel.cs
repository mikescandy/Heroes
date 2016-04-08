using System.Collections.Generic;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class AddWeaponPageModel : BasePageModel
    {
        public List<Weapon> Weapons { get; set; }

        public Weapon SelectedWeapon { get; set; }

        private readonly IRepository repository;

        public AddWeaponPageModel (IRepository repository)
        {
            this.repository = repository;
            Weapons = this.repository.GetAllWeapons ();
        }
    }
}