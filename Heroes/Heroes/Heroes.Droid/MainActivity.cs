using Android.App;
using Android.Content.PM;
using Android.OS;
using XLabs.Forms;

namespace Heroes.Droid
{
    [Activity(Label = "Heroes", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, Theme = "@style/sMain" )]
    public class MainActivity : XFormsApplicationDroid
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
#if _GORILLA_
            LoadApplication (UXDivers.Gorilla.Droid.Player.CreateApplication(ApplicationContext, new UXDivers.Gorilla.Config("Good Gorilla")));
#else
            LoadApplication(new App());
#endif
        }
    }
}

