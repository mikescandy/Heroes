using Android.App;
using Android.Graphics;
using Heroes.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(TabBarTest.Droid.CustomTabRenderer))]

namespace TabBarTest.Droid
{
    public class CustomTabRenderer : TabbedRenderer
    {
        private Activity _activity;
        private Page page;

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
            _activity = this.Context as Activity;
            page = e.NewElement.CurrentPage;
            var actionBar = _activity.ActionBar;
            if (actionBar.TabCount <= 0) return;
            var tabOne = actionBar.GetTabAt(0);
            var id = Common.ResourceIdFromString(page.Icon);
            tabOne.SetIcon(id);
        }

        public override void OnWindowFocusChanged(bool hasWindowFocus)
        {
            // Here the magic happens:  get your ActionBar and select the tab you want to add an image
            var actionBar = _activity.ActionBar;

            if (actionBar.TabCount > 0)
            {
                var tabOne = actionBar.GetTabAt(0);
                var id = Common.ResourceIdFromString(page.Icon);
                tabOne.SetIcon(id);
            }
            base.OnWindowFocusChanged(hasWindowFocus);
        }

        protected override void OnDraw(Canvas canvas)
        {
            var actionBar = _activity.ActionBar;
            if (actionBar.TabCount <= 0) return;
            var tabOne = actionBar.GetTabAt(0);
            var id = Common.ResourceIdFromString(page.Icon);
            tabOne.SetIcon(id);
            base.OnDraw(canvas);
        }
    }
}