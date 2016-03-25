using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    public class RootPage : MasterDetailPage
    {
        public RootPage()
        {

            Master = new ContentPage
            {
                Title = "Master",
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label {Text = "Test 1"},
                        new Label {Text = "Test 2"}
                    }
                }
            };
           
			Detail = new NavigationPage(FreshPageModelResolver.ResolvePageModel<MainTabbedPageModel>()			)
            {
                Title = "Master",
            };




			InvalidateMeasure();
        }
    }
}
