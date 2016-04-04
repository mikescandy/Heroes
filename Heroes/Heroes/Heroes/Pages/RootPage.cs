using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Xamarin.Forms;

namespace Heroes.PageModels
{
	public class RootPage : FreshMasterDetailNavigationContainer
    {
        public RootPage()
        {
			Init("Menu");
			AddPage<HomePageModel>("Home"); 
			AddPage<EquipmentPageModel>("Eq");
					
			InvalidateMeasure();
        }
    }
}
