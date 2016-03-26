using System.Linq;
using Android.Graphics.Drawables;
using Heroes.Droid;

namespace Core.Droid
{
    internal class Common
    {
        internal static int ResourceIdFromString(string name)
        {
            name = name.ToLower()
                .Replace(".png", "")
                .Replace(".jpg", "")
                .Replace(".jpeg", "")
                .Replace(".gif", "")
                .Replace(".ico", "");
            var type = typeof(Resource.Drawable);
            return (from p in type.GetFields()
                    where p.Name.ToLower() == name
                    select (int) p.GetValue(null)).FirstOrDefault();
        }
    }
}