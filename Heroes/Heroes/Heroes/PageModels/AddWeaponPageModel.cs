using System.Collections.Generic;
using System.Windows.Input;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class AddWeaponPageModel : BasePageModel
    {
        public List<Weapon> Weapons { get; set; }

        public Weapon SelectedWeapon { get; set; }

        public ICommand OkCommand { get; set; }

        private readonly IRepository repository;

        public AddWeaponPageModel (IRepository repository)
        {
            this.repository = repository;
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            Weapons = this.repository.GetAllWeapons();

            OkCommand = new Command(async () => await CoreMethods.PopPageModel(SelectedWeapon, true));
        }
    }
}