using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Heroes.Droid
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