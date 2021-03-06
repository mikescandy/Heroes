using System;
using System.Threading;
using Xamarin.Forms;
using Localize = Core.Droid.Localize;

[assembly: Dependency (typeof(Localize))]

namespace Core.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo ()
        {
            var androidLocale = Java.Util.Locale.Default;

            // var netLanguage = androidLocale.Language.Replace ("_", "-");
            var netLanguage = androidLocale.ToString ().Replace ("_", "-");

            // var netLanguage = androidLanguage.Replace ("_", "-");
            Console.WriteLine ("android:" + androidLocale);
            Console.WriteLine ("net:" + netLanguage);

            Console.WriteLine (Thread.CurrentThread.CurrentCulture);
            Console.WriteLine (Thread.CurrentThread.CurrentUICulture);

            return new System.Globalization.CultureInfo (netLanguage);
        }

        public void SetLocale ()
        {
            var androidLocale = Java.Util.Locale.Default; // user's preferred locale
            var netLocale = androidLocale.ToString ().Replace ("_", "-");
            var ci = new System.Globalization.CultureInfo (netLocale);

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}