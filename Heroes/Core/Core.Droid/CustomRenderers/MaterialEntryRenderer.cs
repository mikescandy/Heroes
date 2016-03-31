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

[assembly: ExportRenderer (typeof(ValidationEntry), typeof(MaterialEntryRenderer))]
namespace Core.Droid.CustomRenderers
{
	public class MaterialEntryRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<ValidationEntry, View>
	{
		private TextInputLayout _nativeView;
		private ViewTreeObserver _viewTreeObserver;
		private bool _needsRedraw; 
	private int _oldHeight = -1;
		private TextInputLayout NativeView {
			get { return _nativeView ?? (_nativeView = InitializeNativeView ()); }
		}

		public MaterialEntryRenderer()
		{
			//SetWillNotDraw(false);
		}

		//protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		//{
		//	    double pixels = (double)MeasureSpec.GetSize(widthMeasureSpec);
		//	int num = (int)ContextExtensions.FromPixels(Context, pixels);
		//		SizeRequest sizeRequest = Element.GetSizeRequest((double)num, double.PositiveInfinity);
		//		//Element.Layout(new Rectangle(0.0, 0.0, (double)num, sizeRequest.Request.Height));
		//	double width = NativeView.Width;
		//		int measuredWidth = MeasureSpec.MakeMeasureSpec((int)ContextExtensions.ToPixels(Context, width), MeasureSpecMode.Exactly);
		//	double height = NativeView.Height;
		//		int measuredHeight = MeasureSpec.MakeMeasureSpec((int)ContextExtensions.ToPixels(Context, height), MeasureSpecMode.Exactly);
		//	//this.ViewGroup.Measure(widthMeasureSpec, heightMeasureSpec);
		//	base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
		//}

		//protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		//{
		//	//var measuredWidth = ResolveSize(
		//	//widthMeasureSpec = MeasureSpec.MakeMeasureSpec(measuredWidth,MeasureSpecMode.Exactly);
		//	//heightMeasureSpec = MeasureSpec.MakeMeasureSpec(measuredHeight, MeasureSpecMode.Exactly);





		//	//base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

		 
		//	var widthMode = MeasureSpec.GetMode(widthMeasureSpec);
		//	int widthSize = MeasureSpec.GetSize(widthMeasureSpec);
		//	var heightMode = MeasureSpec.GetMode(heightMeasureSpec);
		//	int heightSize = MeasureSpec.GetSize(heightMeasureSpec);

		//	int width;
		//	int height;

		//	//Measure Width
		//	if (widthMode == MeasureSpecMode.Exactly)
		//	{
		//		//Must be this size
		//		width = widthSize;
		//	}
		//	else if (widthMode == MeasureSpecMode.AtMost)
		//	{
		//		//Can't be bigger than...
		//		width = Math.Min(0, widthSize);
		//	}
		//	else {
		//		//Be whatever you want
		//		width = 0;
		//	}

		//	//Measure Height
		//	if (heightMode == MeasureSpecMode.Exactly)
		//	{
		//		//Must be this size
		//		height = heightSize;
		//	}
		//	else if (heightMode == MeasureSpecMode.AtMost)
		//	{
		//		//Can't be bigger than...
		//		height = Math.Min(0, heightSize);
		//	}
		//	else {
		//		//Be whatever you want
		//		height = 0;
		//	}

		//	//MUST CALL THIS
		//	SetMeasuredDimension(width, 120);



		//}

		//protected override void OnDraw(Android.Graphics.Canvas canvas)
		//{
		//	base.OnDraw(canvas);
		//}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			Console.WriteLine(string.Format("OnLayout height {0}",b-t));
			base.OnLayout(changed, l, t, r, b);
		}

		protected override void OnElementChanged (ElementChangedEventArgs<ValidationEntry> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				var ctrl = CreateNativeControl ();
				SetNativeControl (ctrl);

				_viewTreeObserver = ctrl.ViewTreeObserver;
				_viewTreeObserver.PreDraw += ResizeWebView; //idea && impl from fmg-xamarin-forms

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

			if (e.PropertyName == ValidationEntry.ValidationErrorProperty.PropertyName)
			{
				SetError();
			}
		}

		private void EditTextOnTextChanged (object sender, TextChangedEventArgs textChangedEventArgs)
		{
			Element.Text = textChangedEventArgs.Text.ToString ();
			NativeView.EditText.SetSelection (Element.Text.Length);

		}

		private void SetText ()
		{
			NativeView.EditText.Text = Element.Text;
		}

		private void SetError ()
		{
			if (string.IsNullOrEmpty (Element.ValidationError)) {
				//NativeView.ErrorEnabled = false;
				NativeView.ErrorEnabled = false; 
				NativeView.Error = string.Empty;

			} else {
				//NativeView.ErrorEnabled = true;
				NativeView.ErrorEnabled = true;
				NativeView.Error = Element.ValidationError;
			}
			//Element.HeightRequest = 0;
			_needsRedraw = true;
			//var newHeight = NativeView.Height;
			//var bounds = new Rectangle(Element.Bounds.X, Element.Bounds.Y, Element.Bounds.Width, newHeight);
		}

		private async void ResizeWebView(object sender, EventArgs e)
		{
			if (!_needsRedraw || Element == null) return;
			Console.WriteLine(string.Format("ResizeWebView height {0}", NativeView.Height));
			//var newContentHeight = NativeView.MeasuredHeight;
			NativeView.Measure(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			int width = NativeView.MeasuredWidth;
			int height = NativeView.MeasuredHeight;
			if (height == _oldHeight || height == 0) return;

			//var bounds = new Rectangle(Element.Bounds.X, Element.Bounds.Y, Element.Width, height-20);
			_needsRedraw = false;
			//await Element.LayoutTo(bounds);
			Element.HeightRequest = height;

			// todo: FIX ME
			// not sure why there's the odd case where the height is 8.
			//if (newContentHeight == 8)
			//{
			//	_webView.Reload();
			//	_oldHeight = -1;
			//	return;
			//}
			_needsRedraw = false;
			 _oldHeight = height;
			Console.WriteLine(string.Format("ResizeWebView updated height {0}", NativeView.Height));
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
			if (Element.TextColor == Color.Default) {
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