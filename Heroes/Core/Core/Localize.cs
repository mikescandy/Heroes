using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;

namespace Core
{
    // You exclude the 'Extension' suffix when using in Xaml markup
    public class Localize
    {
        private static readonly CultureInfo Ci;

        static Localize ()
        {
            Ci = DependencyService.Get<ILocalize> ().GetCurrentCultureInfo ();
        }

        public static string GetString (string key, string comment)
        {
            ResourceManager temp = new ResourceManager ("Heroes.AppResources", typeof(Localize).GetTypeInfo ().Assembly);

            string result = temp.GetString (key, Ci);

            return result;
        }
    }
}