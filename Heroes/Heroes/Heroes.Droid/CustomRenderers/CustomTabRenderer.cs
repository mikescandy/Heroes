using System;
using Android.App;
using Android.Graphics;
using Android.Widget;
using Core.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabRenderer))]
namespace Core.Droid.CustomRenderers
{
    public class CustomTabRenderer : TabbedRenderer
    {
        private Activity _activity;
        private TabbedPage _tabbedPage;
        private Page page;




        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);

        //    var pageIndex = int.Parse(page.StyleId);
        //    var actionBar = _activity.ActionBar;
        //    if (actionBar.TabCount <= pageIndex) return;
        //    var tabOne = actionBar.GetTabAt(pageIndex);
        //    var id = Common.ResourceIdFromString(page.Icon);
        //    tabOne.SetIcon(id);
        //}

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
            _activity = this.Context as Activity;
            _tabbedPage = e.NewElement;
            page = e.NewElement.CurrentPage;
            //var pageIndex = int.Parse(page.StyleId);
            //var actionBar = _activity.ActionBar;
            //if (actionBar.TabCount <= pageIndex) return;
            //var tabOne = actionBar.GetTabAt(pageIndex);
            //var id = Common.ResourceIdFromString(page.Icon);
            //tabOne.SetIcon(id);
        }

        private void ActionBarTabsSetup(ActionBar actionBar)
        {
            try
            {
                //_tabbedPage.Children[0].IC
                for (int i = 0; i < actionBar.TabCount; i++)
                {
                    var tabOne = actionBar.GetTabAt(i);
                    var id = Common.ResourceIdFromString(_tabbedPage.Children[i].Icon);
                    tabOne.SetIcon(id);
                    //Android.App.ActionBar.Tab dashboardTab = actionBar.GetTabAt(i);
                    //if (TabIsEmpty(dashboardTab))
                    //{

                    //    int id = Resources.GetIdentifier(_tabbedPage.Children[i].Icon.File, "drawable", Context.PackageName);
                    //    TabSetup(dashboardTab, id);
                    //}

                }

            }
            catch (Exception)
            {

            }

        }

        private bool TabIsEmpty(ActionBar.Tab tab)
        {
            if (tab != null)
                if (tab.CustomView == null)
                    return true;
            return false;
        }

        private void TabSetup(ActionBar.Tab tab, int resourceID)
        {
            var iv = new ImageView(_activity);
            iv.SetImageResource(resourceID);
            iv.SetPadding(0, 10, 0, 0);
            tab.SetCustomView(iv);
        }

        //public override void OnWindowFocusChanged(bool hasWindowFocus)
        //{
        //    // Here the magic happens:  get your ActionBar and select the tab you want to add an image
        //    var actionBar = _activity.ActionBar;

        //    if (actionBar.TabCount > 0)
        //    {
        //    var pageIndex = int.Parse(page.StyleId);
        //        var tabOne = actionBar.GetTabAt(pageIndex);
        //        var id = Common.ResourceIdFromString(page.Icon);
        //        tabOne.SetIcon(id);
        //    }
        //    base.OnWindowFocusChanged(hasWindowFocus);
        //}

        //protected override void OnDraw(Canvas canvas)
        //{
        //    base.OnDraw(canvas);
        //    var actionBar = _activity.ActionBar;
        //    var pageIndex = int.Parse(page.StyleId);
        //    if (actionBar.TabCount <= pageIndex) return;
        //    var tabOne = actionBar.GetTabAt(pageIndex);
        //    var id = Common.ResourceIdFromString(page.Icon);
        //    tabOne.SetIcon(id);
        //}

        protected override void DispatchDraw(Canvas canvas)
        {
            var actionBar = _activity.ActionBar;


            if (actionBar.TabCount > 0)
            {
                //ColorDrawable colorDrawable = new ColorDrawable(global::Android.Graphics.Color.ParseColor(COLOR));
                //actionBar.SetStackedBackgroundDrawable(colorDrawable);
                ActionBarTabsSetup(actionBar);

            }
            base.DispatchDraw(canvas);
        }
    }
}