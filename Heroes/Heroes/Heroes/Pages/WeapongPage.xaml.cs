using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Heroes.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeaponPage : ContentPage
    {
        public WeaponPage ()
        {
            InitializeComponent ();
        }

        protected override void OnAppearing ()
        {
            base.OnAppearing ();
        }
    }
}