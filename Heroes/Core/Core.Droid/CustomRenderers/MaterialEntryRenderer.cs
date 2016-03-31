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
			//SetWillNotDraw(false);
		}

//		protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
//		{
//			if (_view == null)
//				return;
//			_view.Element.Layout(new Rectangle(0.0, 0.0, ContextExtensions.FromPixels(Context, right - left), ContextExtensions.FromPixels(Context, bottom - top)));
//			_view.UpdateLayout();
//		}
//
//		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
//		{
//			MeasureSpecMode widthMode = MeasureSpec.GetMode(widthMeasureSpec);
//			MeasureSpecMode heightMode = MeasureSpec.GetMode(heightMeasureSpec);
//			int widthSize = MeasureSpec.GetSize(widthMeasureSpec);
//			int heightSize = MeasureSpec.GetSize(heightMeasureSpec);
//			int pxHeight = (int)ContextExtensions.ToPixels(Context, _view.Element.HeightRequest);
//			int pxWidth = (int)ContextExtensions.ToPixels(Context, _view.Element.WidthRequest);
//			var measuredWidth = widthMode != MeasureSpecMode.Exactly ? (widthMode != MeasureSpecMode.AtMost ? pxHeight : Math.Min(pxHeight, widthSize)) : widthSize;
//			var measuredHeight = heightMode != MeasureSpecMode.Exactly ? (heightMode != MeasureSpecMode.AtMost ? pxWidth : Math.Min(pxWidth, heightSize)) : heightSize;
//			SetMeasuredDimension(measuredWidth, measuredHeight);
//		}


		//protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		//{
		//	    double pixels = (double)MeasureSpec.GetSize(widthMeasureSpec);
		//	int num = (int)ContextExtensions.FromPixels(Context, pixels);
		//		SizeRequest sizeRequest = Element.GetSizeRequest((double)num, double.PositiveInfinity);
		//	var hheight = NativeView.Height;
		//	if (!string.IsNullOrEmpty(NativeView.Error))
		//		hheight = NativeView.Height + 50;
		//		Element.Layout(new Rectangle(Element.X, Element.Y, (double)num, hheight));
		//	double width = NativeView.Width;
		//		int measuredWidth = MeasureSpec.MakeMeasureSpec((int)ContextExtensions.ToPixels(Context, width), MeasureSpecMode.Exactly);
		//	double height = NativeView.Height;
		//		int measuredHeight = MeasureSpec.MakeMeasureSpec((int)ContextExtensions.ToPixels(Context, height), MeasureSpecMode.Exactly);
		//		//this.ViewGroup.Measure(widthMeasureSpec, heightMeasureSpec);
		//		this.SetMeasuredDimension(measuredWidth, measuredHeight);


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

		protected override void OnElementChanged (ElementChangedEventArgs<ValidationEntry> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				var ctrl = CreateNativeControl ();
				SetNativeControl (ctrl);
				_viewTreeObserver = NativeView.ViewTreeObserver;
				_viewTreeObserver.PreDraw += ResizeWebView;
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
			
			var newContentHeight = NativeView.MeasuredHeight;

			int measuredHeight = MeasureSpec.MakeMeasureSpec((int)ContextExtensions.ToPixels(Context, newContentHeight), MeasureSpecMode.Exactly);
			float px = newContentHeight /Context.Resources.DisplayMetrics.Density;

			Console.WriteLine ("dens: "+Context.Resources.DisplayMetrics.Density );
			Console.WriteLine ("ele: "+Element.Height);
			Console.WriteLine ("eled: "+Element.HeightRequest);
			Console.WriteLine ("new: "+NativeView.Height);
			Console.WriteLine ("new px: "+px);
			Console.WriteLine ("meas: "+measuredHeight);
				

			if (!_needsRedraw || Element == null) return;

			//NativeView.Invalidate ();
			if (newContentHeight == _oldHeight || newContentHeight == 0) return;
			var height = newContentHeight / Context.Resources.DisplayMetrics.Density;
			height = NativeView.ErrorEnabled ? 82 : 58;
			var bounds = new Rectangle(Element.Bounds.X, Element.Bounds.Y, Element.Bounds.Width, height);
			await Element.LayoutTo(bounds, 250,Easing.SinIn);
			Element.HeightRequest = height;
			// todo: FIX ME
			// not sure why there's the odd case where the height is 8.
			if (newContentHeight == 8)
			{
				//_webView.Reload();
				_oldHeight = -1;
				return;
			}

			_oldHeight = (int)height;
			_needsRedraw = false;
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