using System;
using Android.App;
using Android.Graphics;
using Android.Support.Design.Widget;
using Core.Controls;
using Core.Droid.CustomRenderers;
 
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Util;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabRenderer))]
namespace Core.Droid.CustomRenderers
{
    public class CustomTabRenderer : TabbedPageRenderer
    {
        private Activity _activity;
        private TabbedPage _tabbedPage;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
            _activity = this.Context as Activity;
            _tabbedPage = e.NewElement;
        }

        private void ActionBarTabsSetup(TabLayout actionBar)
        {
            try
            {
                for (var i = 0; i < actionBar.TabCount; i++)
                {
                    var tabOne = actionBar.GetTabAt(i);
                    if (tabOne.Icon != null)
                    {
                        return;
                    }
                    var id = Common.ResourceIdFromString(_tabbedPage.Children[i].Icon);
                    tabOne.SetIcon(id);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Heroes", ex.Message);
            }
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            var actionBar = _activity.FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            if (actionBar != null && actionBar.TabCount > 0)
            {
                ActionBarTabsSetup(actionBar);
            }
            base.DispatchDraw(canvas);
        }
    }
}