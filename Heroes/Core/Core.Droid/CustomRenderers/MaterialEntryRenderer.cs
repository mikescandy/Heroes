using System;
using System.ComponentModel;
using Android.Content.Res;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Util;
using Android.Views;
using Core;
using Core.Controls;
using Core.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TextChangedEventArgs = Android.Text.TextChangedEventArgs;
using View = Android.Views.View;

[assembly: ExportRenderer (typeof(ValidationEntry), typeof(MaterialEntryRenderer))]

namespace Core.Droid.CustomRenderers
{
    public class MaterialEntryRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<ValidationEntry, View>
    {
        private TextInputLayout nativeView;
        private bool needsRedraw;
        private int oldHeight = -1;
        private ViewTreeObserver viewTreeObserver;

        private TextInputLayout NativeView
        {
            get { return nativeView ?? (nativeView = InitializeNativeView ()); }
        }

        public MaterialEntryRenderer ()
        {
            SetWillNotDraw (false);
        }

        public void SetBackgroundColor ()
        {
            NativeView.SetBackgroundColor (Element.BackgroundColor.ToAndroid ());
        }

        protected override void OnElementChanged (ElementChangedEventArgs<ValidationEntry> e)
        {
            base.OnElementChanged (e);

            if (e.OldElement == null)
            {
                var ctrl = CreateNativeControl ();
                SetNativeControl (ctrl);
                viewTreeObserver = NativeView.ViewTreeObserver;
                viewTreeObserver.PreDraw += ResizeWebView;
                NativeView.LayoutChange += (object sender, LayoutChangeEventArgs ee) => {
                    Console.WriteLine ("Layout change: " + (ee.Bottom - ee.Top));
                };

                SetText ();
                SetHintText ();
                SetBackgroundColor ();
                SetTextColor ();
                SetIsPassword ();
            }
        }

        protected override View CreateNativeControl ()
        {
            return LayoutInflater.From (Context).Inflate (Resource.Layout.TextInputLayout, null);
        }

        protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);
            Console.WriteLine (string.Format ("{0}", e.PropertyName));
            if (e.PropertyName == Entry.PlaceholderProperty.PropertyName)
            {
                SetHintText ();
            }

            if (e.PropertyName == Entry.TextColorProperty.PropertyName)
            {
                SetTextColor ();
            }

            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                SetBackgroundColor ();
            }

            if (e.PropertyName == Entry.IsPasswordProperty.PropertyName)
            {
                SetIsPassword ();
            }

            if (e.PropertyName == Entry.TextProperty.PropertyName)
            {
                SetText ();
            }

            if (e.PropertyName == ValidationEntry.ValidationErrorProperty.PropertyName)
            {
                SetError ();
            }
        }

        private void EditTextOnTextChanged (object sender, TextChangedEventArgs textChangedEventArgs)
        {
            Element.Text = textChangedEventArgs.Text.ToString ();
            NativeView.EditText.SetSelection (Element.Text.Length);
        }

        private async void ResizeWebView (object sender, EventArgs e)
        {
            if (!needsRedraw || Element == null)
            {
                return;
            }

            var newContentHeight = NativeView.MeasuredHeight;

            int measuredHeight = MeasureSpec.MakeMeasureSpec ((int)ContextExtensions.ToPixels (Context, newContentHeight), MeasureSpecMode.Exactly);
            float px = newContentHeight / Context.Resources.DisplayMetrics.Density;

            Console.WriteLine ("dens: " + Context.Resources.DisplayMetrics.Density);

            var textSize = 0;
            for (var i = 0; i < NativeView.ChildCount; i++)
            {
                if (i == 0)
                {
                    var c = NativeView.GetChildAt (0) as Android.Support.V7.Widget.AppCompatEditText;
                    if (c != null)
                    {
                        textSize += (int)c.TextSize + c.PaddingTop + c.PaddingBottom;
                    }
                }
            
                if (i == 1)
                {
                    var c = NativeView.GetChildAt (1) as Android.Widget.TextView;
                    if (c != null)
                    {
                        textSize += (int)c.TextSize + c.PaddingTop + c.PaddingBottom;
                    }
                }
            }

            Console.WriteLine ("textSize: " + textSize);
            var height = (int)(textSize * Context.Resources.DisplayMetrics.Density);

            if (height == oldHeight || newContentHeight == 0)
            {
                return;
            }

            var bounds = new Rectangle (Element.Bounds.X, Element.Bounds.Y, Element.Bounds.Width, height);
            await Element.LayoutTo (bounds, 250);
            Element.HeightRequest = height;

            oldHeight = (int)height;
            needsRedraw = false;
        }

        private void SetText ()
        {
            NativeView.EditText.Text = Element.Text;
        }

        private void SetError ()
        {
            NativeView.Invalidate ();
            NativeView.ForceLayout ();

            NativeView.RequestLayout ();
            if (string.IsNullOrEmpty (Element.ValidationError))
            {
                NativeView.ErrorEnabled = false; 
                NativeView.Error = string.Empty;
            }
            else
            {
                NativeView.ErrorEnabled = true;
                NativeView.Error = Element.ValidationError;
            }

            needsRedraw = true;
        }

        private void SetIsPassword ()
        {
            NativeView.EditText.InputType = Element.IsPassword
                ? InputTypes.TextVariationPassword | InputTypes.ClassText
                : NativeView.EditText.InputType;
        }

        private void SetHintText ()
        {
            NativeView.Hint = Element.Placeholder;
        }

        private void SetTextColor ()
        {
            if (Element.TextColor == Xamarin.Forms.Color.Default)
            {
                NativeView.EditText.SetTextColor (NativeView.EditText.TextColors);
            }
            else
            {
                NativeView.EditText.SetTextColor (Element.TextColor.ToAndroid ());
            }
        }

        private TextInputLayout InitializeNativeView ()
        {
            var view = FindViewById<TextInputLayout> (Resource.Id.textInputLayout);
            view.EditText.TextChanged += EditTextOnTextChanged;
            return view;
        }
    }
}