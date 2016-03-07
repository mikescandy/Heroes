using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
