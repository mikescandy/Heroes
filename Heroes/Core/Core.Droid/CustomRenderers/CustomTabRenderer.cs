using System;
using Android.App;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Util;
using Core.Controls;
using Core.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer (typeof(CustomTabbedPage), typeof(CustomTabRenderer))]

namespace Core.Droid.CustomRenderers
{
    public class CustomTabRenderer : TabbedPageRenderer
    {
        private Activity activity;
        private TabbedPage tabbedPage;

        protected override void OnElementChanged (Xamarin.Forms.Platform.Android.ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged (e);
            this.activity = this.Context as Activity;
            this.tabbedPage = e.NewElement;
        }

        protected override void DispatchDraw (Canvas canvas)
        {
            var actionBar = activity.FindViewById<TabLayout> (Resource.Id.sliding_tabs);
            if (actionBar != null && actionBar.TabCount > 0)
            {
                ActionBarTabsSetup (actionBar);
            }

            base.DispatchDraw (canvas);
        }

        private void ActionBarTabsSetup (TabLayout actionBar)
        {
            try
            {
                for (var i = 0; i < actionBar.TabCount; i++)
                {
                    var tabOne = actionBar.GetTabAt (i);
                    if (tabOne.Icon != null)
                    {
                        return;
                    }

                    var id = Common.ResourceIdFromString (tabbedPage.Children [i].Icon);
                    tabOne.SetIcon (id);
                }
            }
            catch (Exception ex)
            {
                Log.Error ("Heroes", ex.Message);
            }
        }
    }
}