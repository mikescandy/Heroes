using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Heroes.Droid
{
    [Activity(Label = "Heroes",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);
            Forms.Init(this, bundle);

#if _GORILLA_
            LoadApplication (UXDivers.Gorilla.Droid.Player.CreateApplication(ApplicationContext, new UXDivers.Gorilla.Config("Good Gorilla")));
#else
            LoadApplication(new App());
#endif
        }
    }
}

