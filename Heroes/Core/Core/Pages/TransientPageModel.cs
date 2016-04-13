using System;
using System.Linq;

namespace Core.Pages
{
    public class TransientPageModel : BasePageModel
    {
        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
            RemoveFromStack();
        }

        protected virtual void RemoveFromStack()
        {
            if (CurrentPage.Navigation.NavigationStack.Contains(CurrentPage))
            {
                CurrentPage.Navigation.RemovePage(CurrentPage);
            }
        }
    }
}
