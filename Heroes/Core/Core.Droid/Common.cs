using Android.App;

namespace Core.Droid
{
    public class Common
    {
        public static int ResourceIdFromString(string name, string packageName = null)
        {
            name = name.ToLower()
                .Replace(".png", "")
                .Replace(".jpg", "")
                .Replace(".jpeg", "")
                .Replace(".gif", "")
                .Replace(".ico", "");
            return Application.Context.Resources.GetIdentifier(name, "drawable", packageName ?? Application.Context.PackageName);
        }
    }
}