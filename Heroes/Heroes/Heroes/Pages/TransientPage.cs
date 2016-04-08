using System.Linq;

namespace Heroes.Pages
{
    public class TransientPage : BasePage
    {
        protected override void OnDisappearing ()
        {
            base.OnDisappearing ();
            if (Navigation.NavigationStack.Contains (this))
            {
                Navigation.RemovePage (this);
            }
        }
    }
}