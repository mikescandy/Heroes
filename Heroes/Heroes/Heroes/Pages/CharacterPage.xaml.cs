using Xamarin.Forms;

namespace Heroes
{
    public partial class CharacterPage : ContentPage
    {
        public CharacterPage()
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
           tbi = new ToolbarItem("", "editUser", async () =>
           {
          var basePageModel = this.BindingContext as CharacterPageModel;
          if (basePageModel != null)
          {
              {
             await basePageModel.CoreMethods.PushPageModel<EditCharacterPageModel>(basePageModel.Character.ID, true); // Pushes a Modal
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
