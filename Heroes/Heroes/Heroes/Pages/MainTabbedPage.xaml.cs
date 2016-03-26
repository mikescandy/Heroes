using Core;
using FreshMvvm;
using Xamarin.Forms;

namespace Heroes
{
	public partial class MainTabbedPage : NavigationPage
    {
        public MainTabbedPage()

        {
			var tp = new CustomTabbedPage();
            var characterPage = FreshPageModelResolver.ResolvePageModel<CharacterPageModel>();
            characterPage.Title = "q";
            characterPage.Icon = "user.png";

            var equipmentPage = FreshPageModelResolver.ResolvePageModel<EquipmentPageModel>();
            equipmentPage.Title = "q";
            equipmentPage.Icon = "bag.png";

            var weaponPage = FreshPageModelResolver.ResolvePageModel<WeaponPageModel>();
            weaponPage.Title = "q";
            weaponPage.Icon = "sword.png";

            tp.Children.Add(FreshPageModelResolver.ResolvePageModel<CharacterPageModel>());
            tp.Children.Add(FreshPageModelResolver.ResolvePageModel<EquipmentPageModel>());
            tp.Children.Add(FreshPageModelResolver.ResolvePageModel<WeaponPageModel>());
			this.PushAsync(tp);
        }
    }
}
