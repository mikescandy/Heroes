using Android.App;
using Android.Content;
using Android.Util;

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

//		public static float dpFromPx(final Context context, final float px) {
//			return px / context.getResources().getDisplayMetrics().density;
//		}
//
//		public static float pxFromDp(final Context context, final float dp) {
//			return dp * context.getResources().getDisplayMetrics().density;
//		}

//		/**
// * This method converts dp unit to equivalent pixels, depending on device density. 
// * 
// * @param dp A value in dp (density independent pixels) unit. Which we need to convert into pixels
// * @param context Context to get resources and device specific display metrics
// * @return A float value to represent px equivalent to dp depending on device density
// */
//		public static float convertDpToPixel(float dp, Context context){
//			var resources = context.Resources;
//			var metrics = resources.DisplayMetrics;
//			float px = dp * ((float)metrics.DensityDpi / DisplayMetricsDensity.Default);
//			return px;
//		}
//
//		/**
// * This method converts device specific pixels to density independent pixels.
// * 
// * @param px A value in px (pixels) unit. Which we need to convert into db
// * @param context Context to get resources and device specific display metrics
// * @return A float value to represent dp equivalent to px value
// */
//		public static float convertPixelsToDp(float px, Context context){
//			var resources = context.Resources;
//			var metrics = resources.DisplayMetrics;
//			float dp = px / ((float)metrics.DensityDpi / DisplayMetricsDensity.Default);
//			return dp;
//		}
//

    }
}