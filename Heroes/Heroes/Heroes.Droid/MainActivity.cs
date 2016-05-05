using Android.App;
using Android.Content.PM;
using Android.OS;
using SVG.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Heroes.Droid
{
    /// <inheritdoc/>
    [Activity (Label = "Heroes",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        /// <inheritdoc/>
        protected override void OnCreate (Bundle bundle)
        {
            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate (bundle);
            Forms.Init (this, bundle);
            SvgImageRenderer.Init ();

#if _GORILLA_
            LoadApplication (UXDivers.Gorilla.Droid.Player.CreateApplication(ApplicationContext, new UXDivers.Gorilla.Config("Good Gorilla")));
#else
           // LoadApplication (new App ());
            var a = new App();
           LoadApplication(new Xamarin.Forms.Player.App(a));
#endif
        }
    }
}