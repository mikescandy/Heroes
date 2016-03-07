using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Xamarin.Forms;

namespace Heroes
{
    public partial class EquipmentPage : ContentPage
    {
        public EquipmentPage()
        {
            InitializeComponent();
            #region toolbar
            ToolbarItem tbi = null;
            if (Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                {
                    //var todoItem = new TodoItem();
                    //var todoPage = new TodoItemPage();
                    //todoPage.BindingContext = todoItem;
                    //Navigation.PushAsync(todoPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("", "plus", async () =>
                {
                    var basePageModel = this.BindingContext as FreshMvvm.FreshBasePageModel;
                    if (basePageModel != null)
                    {
                       
                        {
                           await basePageModel.CoreMethods.PushPageModel<AddEquipmentPageModel>(null, true); // Pushes a Modal
                            var p = 5;
                            p++;
                        } 
                    }
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                tbi = new ToolbarItem("Add", "add.png", () =>
                {
                    //var todoItem = new TodoItem();
                    //var todoPage = new TodoItemPage();
                    //todoPage.BindingContext = todoItem;
                    //Navigation.PushAsync(todoPage);
                }, 0, 0);
            }

            ToolbarItems.Add(tbi);
            #endregion

        }

        protected override void OnAppearing()
        {
            // NavigationPage.SetHasNavigationBar(this, false);

            base.OnAppearing();
        }
    }
}
