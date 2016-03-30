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

[assembly: ExportRenderer (typeof(ValidationEntry), typeof(MaterialEntryRenderer))]
namespace Core.Droid.CustomRenderers
{
	public class MaterialEntryRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<ValidationEntry, View>
	{
		private TextInputLayout _nativeView;

		private TextInputLayout NativeView {
			get { return _nativeView ?? (_nativeView = InitializeNativeView ()); }
		}


		protected override void OnElementChanged (ElementChangedEventArgs<ValidationEntry> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				var ctrl = CreateNativeControl ();
				SetNativeControl (ctrl);

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
			Invalidate();
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