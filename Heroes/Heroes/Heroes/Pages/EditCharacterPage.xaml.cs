using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Heroes
{
    public partial class EditCharacterPage : ContentPage
    {
        public EditCharacterPage()
        {
            InitializeComponent();
            #region toolbar
            ToolbarItem tbi1 = null;
            ToolbarItem tbi2 = null;
            if (Device.OS == TargetPlatform.iOS)
            {
                tbi1 = new ToolbarItem("+", null, () =>
                {
                    //var todoItem = new TodoItem();
                    //var todoPage = new TodoItemPage();
                    //todoPage.BindingContext = todoItem;
                    //Navigation.PushAsync(todoPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi1 = new ToolbarItem("", "save", async () =>
                {
                    var basePageModel = this.BindingContext as EditCharacterPageModel;
                    if (basePageModel != null)
                    {
                        {
                            await basePageModel.CoreMethods.PopPageModel(basePageModel.Character, true); // Pushes a Modal
                        }
                    }
                }, 0, 0);
                tbi2 = new ToolbarItem("", "cancel", async () =>
                {
                    var basePageModel = this.BindingContext as EditCharacterPageModel;
                    if (basePageModel != null)
                    {
                        {
                            await basePageModel.CoreMethods.PopPageModel(null, true); // Pushes a Modal
                        }
                    }
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                tbi1 = new ToolbarItem("Add", "add.png", () =>
                {
                    //var todoItem = new TodoItem();
                    //var todoPage = new TodoItemPage();
                    //todoPage.BindingContext = todoItem;
                    //Navigation.PushAsync(todoPage);
                }, 0, 0);
            }

            ToolbarItems.Add(tbi1);
            ToolbarItems.Add(tbi2);
            #endregion
        }
    }
}
