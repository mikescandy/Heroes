using System.Linq;
using Xamarin.Forms;

namespace Heroes
{
    public partial class AddEquipmentPage : ContentPage
    {
        public AddEquipmentPage()
        {
            InitializeComponent();
            #region toolbar
            ToolbarItem tbi = null;
            ToolbarItem tbi2 = null;
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
                tbi = new ToolbarItem("", "ok", async () =>
                {
                    var basePageModel = this.BindingContext as AddEquipmentPageModel;
                    if (basePageModel != null)
                    {
                        object result;
                        result = basePageModel.MultiSelect
                            ? (object) basePageModel.AdventuringGears.Where(m => m.IsSelected).ToList()
                            : basePageModel.SelectedAdventuringGear;
                               await basePageModel.CoreMethods.PopPageModel(result, true); // Pushes a Modal
                        
                    }
                }, 0, 0);

                tbi2 = new ToolbarItem("", "multiselect", () =>
                {
                    var basePageModel = this.BindingContext as AddEquipmentPageModel;

                    if (basePageModel != null)
                    {
                        basePageModel.MultiSelect = !basePageModel.MultiSelect;
                        foreach (var equipmentViewModel in basePageModel.AdventuringGears)
                        {
                            equipmentViewModel.CheckboxVisible = basePageModel.MultiSelect;
                        }
                    }
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                tbi = new ToolbarItem("Ok", "ok.png", () =>
                {
                    //var todoItem = new TodoItem();
                    //var todoPage = new TodoItemPage();
                    //todoPage.BindingContext = todoItem;
                    //Navigation.PushAsync(todoPage);
                }, 0, 0);
            }

            ToolbarItems.Add(tbi2);
            ToolbarItems.Add(tbi);
            #endregion

        }
    }
}
