using Core;
using Core.Controls;
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

            tp.Children.Add(characterPage);
            tp.Children.Add(equipmentPage);
            tp.Children.Add(weaponPage);
			this.PushAsync(tp);
        }
    }
}
