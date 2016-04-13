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
    }
}