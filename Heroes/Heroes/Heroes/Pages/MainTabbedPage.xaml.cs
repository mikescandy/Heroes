using FreshMvvm;
using Xamarin.Forms;

namespace Heroes
{
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()

        {
            var characterPage = FreshPageModelResolver.ResolvePageModel<CharacterPageModel>();
            characterPage.Title = "";
            characterPage.Icon = "user.png";

            var equipmentPage = FreshPageModelResolver.ResolvePageModel<EquipmentPageModel>();
            equipmentPage.Title = "";
            equipmentPage.Icon = "bag.png";

            var weaponPage = FreshPageModelResolver.ResolvePageModel<WeaponPageModel>();
            weaponPage.Title = "";
            weaponPage.Icon = "sword.png";

            Children.Add(FreshPageModelResolver.ResolvePageModel<CharacterPageModel>());
            Children.Add(FreshPageModelResolver.ResolvePageModel<EquipmentPageModel>());
            Children.Add(FreshPageModelResolver.ResolvePageModel<WeaponPageModel>());
        }
    }
}
