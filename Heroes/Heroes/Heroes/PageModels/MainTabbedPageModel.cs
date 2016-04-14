using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Pages;
using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public sealed class MainTabbedPageModel : BasePageModel
    {
        public ObservableCollection<Page> TabPageList { get; set; }

        public override void Init (object initData)
        {
            base.Init (initData);

            var characterPage = FreshPageModelResolver.ResolvePageModel<CharacterPageModel> (initData);
            characterPage.Title = "q";
            characterPage.Icon = "user.png";

            var equipmentPage = FreshPageModelResolver.ResolvePageModel<EquipmentPageModel> (initData);
            equipmentPage.Title = "q";
            equipmentPage.Icon = "bag.png";

            var weaponPage = FreshPageModelResolver.ResolvePageModel<WeaponPageModel> (initData);
            weaponPage.Title = "q";
            weaponPage.Icon = "sword.png";

            var pageList = new List<Page> { 
                characterPage, equipmentPage, weaponPage
            };

            TabPageList = new ObservableCollection<Page> (pageList);
        }
    }
}
