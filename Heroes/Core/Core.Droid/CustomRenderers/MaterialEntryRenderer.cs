using System.ComponentModel;
using Android.Support.Design.Widget;
using Android.Text;
using Android.Views;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TextChangedEventArgs = Android.Text.TextChangedEventArgs;
using View = Android.Views.View;
using Core.Droid.CustomRenderers;
using Core;
using Core.Controls;
using System;
using Android.Util;
using Android.Support.V7.Widget;
using Android.Graphics;
using Android.Content.Res;

[assembly: ExportRenderer (typeof(ValidationEntry), typeof(MaterialEntryRenderer))]
namespace Core.Droid.CustomRenderers
{
	public class MaterialEntryRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<ValidationEntry, View>
	{
		private TextInputLayout _nativeView;
		private bool _needsRedraw;
		private int _oldHeight = -1;
		private ViewTreeObserver _viewTreeObserver;

		private TextInputLayout NativeView {
			get { return _nativeView ?? (_nativeView = InitializeNativeView ()); }
		}

		public MaterialEntryRenderer()
		{
			SetWillNotDraw(false);
		}

		protected override void OnElementChanged (ElementChangedEventArgs<ValidationEntry> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				var ctrl = CreateNativeControl ();
				SetNativeControl (ctrl);
				_viewTreeObserver = NativeView.ViewTreeObserver;
				_viewTreeObserver.PreDraw += ResizeWebView;
				NativeView.LayoutChange += (object sender, LayoutChangeEventArgs ee) => {
					Console.WriteLine ("Layout change: "+ (ee.Bottom-ee.Top));
				};
				 
				SetText ();
				SetHintText ();
				SetBackgroundColor ();
				SetTextColor ();
				SetIsPassword ();
			}
		}

		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			Console.WriteLine (string.Format("{0}",e.PropertyName));
			if (e.PropertyName == Entry.PlaceholderProperty.PropertyName) {
				SetHintText ();
			}

			if (e.PropertyName == Entry.TextColorProperty.PropertyName) {
				SetTextColor ();
			}

			if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName) {
				SetBackgroundColor ();
			}

			if (e.PropertyName == Entry.IsPasswordProperty.PropertyName) {
				SetIsPassword ();
			}

			if (e.PropertyName == Entry.TextProperty.PropertyName) {
				SetText ();
			}

			if (e.PropertyName == ValidationEntry.ValidationErrorProperty.PropertyName) {
				SetError ();
			}

		}

		private void EditTextOnTextChanged (object sender, TextChangedEventArgs textChangedEventArgs)
		{
			Element.Text = textChangedEventArgs.Text.ToString ();
			NativeView.EditText.SetSelection (Element.Text.Length);

		}

		private async void ResizeWebView(object sender, EventArgs e)
		{
			if (!_needsRedraw || Element == null) return;

			var newContentHeight = NativeView.MeasuredHeight;

			int measuredHeight = MeasureSpec.MakeMeasureSpec((int)ContextExtensions.ToPixels(Context, newContentHeight), MeasureSpecMode.Exactly);
			float px = newContentHeight /Context.Resources.DisplayMetrics.Density;

			Console.WriteLine ("dens: "+Context.Resources.DisplayMetrics.Density );

			var textSize = 0;
			for (var i = 0; i < NativeView.ChildCount; i++) {
				if (i == 0) {
					var c = NativeView.GetChildAt (0) as Android.Support.V7.Widget.AppCompatEditText;
					if (c != null) {
						textSize += (int)c.TextSize+c.PaddingTop+c.PaddingBottom;
					}
				}
				if (i == 1) {
					var c = NativeView.GetChildAt (1) as 	Android.Widget.TextView;
					if (c != null) {
						textSize += (int)c.TextSize+c.PaddingTop+c.PaddingBottom;

					}
				}
			}
			Console.WriteLine ("textSize: "+textSize);
			var height = (int)(textSize * Context.Resources.DisplayMetrics.Density);

			//NativeView.Invalidate ();
			if (height == _oldHeight || newContentHeight == 0) return;
		
			var bounds = new Rectangle(Element.Bounds.X, Element.Bounds.Y, Element.Bounds.Width, height);
			await Element.LayoutTo(bounds, 250);
			Element.HeightRequest = height;
			// todo: FIX ME
			// not sure why there's the odd case where the height is 8.
//			if (newContentHeight == 8)
//			{
//				//_webView.Reload();
//				_oldHeight = -1;
//				return;
//			}

			_oldHeight = (int)height;
			_needsRedraw = false;
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
			if (string.IsNullOrEmpty (Element.ValidationError)) {
				//NativeView.ErrorEnabled = false;
				NativeView.ErrorEnabled = false; 
				NativeView.Error = string.Empty;

			} else {
				//NativeView.ErrorEnabled = true;
				NativeView.ErrorEnabled = true;
				NativeView.Error = Element.ValidationError;
			}
			_needsRedraw = true;
		}

		private void SetIsPassword ()
		{
			NativeView.EditText.InputType = Element.IsPassword
				? InputTypes.TextVariationPassword | InputTypes.ClassText
				: NativeView.EditText.InputType;
		}

		public void SetBackgroundColor ()
		{
			NativeView.SetBackgroundColor (Element.BackgroundColor.ToAndroid ());
		}

		private void SetHintText ()
		{
			NativeView.Hint = Element.Placeholder;
		}

		private void SetTextColor ()
		{
			if (Element.TextColor == Xamarin.Forms.Color.Default) {
				NativeView.EditText.SetTextColor (NativeView.EditText.TextColors);
			} else {
				NativeView.EditText.SetTextColor (Element.TextColor.ToAndroid ());
			}
		}

		private TextInputLayout InitializeNativeView ()
		{
			var view = FindViewById<TextInputLayout> (Resource.Id.textInputLayout);
			view.EditText.TextChanged += EditTextOnTextChanged;
			return view;
		}

		protected override View CreateNativeControl ()
		{
			return LayoutInflater.From (Context).Inflate (Resource.Layout.TextInputLayout, null);
		}
	}
}