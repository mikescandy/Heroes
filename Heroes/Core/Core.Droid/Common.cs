using Android.App;

namespace Core.Droid
{
    public class Common
    {
        public static int ResourceIdFromString (string name, string packageName = null)
        {
            name = name.ToLower ()
                .Replace (".png", string.Empty)
                .Replace (".jpg", string.Empty)
                .Replace (".jpeg", string.Empty)
                .Replace (".gif", string.Empty)
                .Replace (".ico", string.Empty);
            return Application.Context.Resources.GetIdentifier (name, "drawable", packageName ?? Application.Context.PackageName);
        }
    }
}