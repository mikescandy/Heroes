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

                        {
                            await basePageModel.CoreMethods.PopPageModel(basePageModel.SelectedAdventuringGear, true); // Pushes a Modal
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

            ToolbarItems.Add(tbi);
            #endregion

        }
    }
}
