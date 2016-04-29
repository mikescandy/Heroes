using System;
using System.Linq;
using Core.Pages;
using FreshMvvm;
using PropertyChanged;

namespace Core.Pages
{
    [ImplementPropertyChanged]
    public abstract class BasePageModel : FreshBasePageModel, IBasePageModel
    {
        public string Title { get; set; }

        public string Image { get; set; }

        public bool Transient { get; set; }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
            if(Transient)
            {
             RemoveFromStack();   
            }
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