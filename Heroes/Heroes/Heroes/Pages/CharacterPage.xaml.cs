using Xamarin.Forms;

namespace Heroes
{
    public partial class CharacterPage : ContentPage
    {
        public CharacterPage()
        {
             InitializeComponent();
        }

        protected override void OnAppearing()
        {
           // NavigationPage.SetHasNavigationBar(this, false);
            base.OnAppearing();
        }
    }
}
