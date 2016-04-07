using FreshMvvm;
using Heroes.PageModels;

namespace Heroes.Pages
{
    public class RootPage : FreshMasterDetailNavigationContainer
    {
        public RootPage ()
        {
            Init ("Menu");
            AddPage<HomePageModel> ("Home"); 
            AddPage<EquipmentPageModel> ("Eq");
            InvalidateMeasure ();
        }
    }
}