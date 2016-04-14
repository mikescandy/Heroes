using System.Collections.ObjectModel;
using System.Windows.Input;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public sealed class WeaponPageModel : BasePageModel
    {
        private readonly IRepository repository;

        public ICommand AddWeaponCommand { get; set; }

        public WeaponPageModel (IRepository repository)
        {
            this.repository = repository;
        }

        public override void Init (object initData)
        {
            AddWeaponCommand = new Command (async () => await CoreMethods.PushPageModel<AddWeaponPageModel> (null, true));
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