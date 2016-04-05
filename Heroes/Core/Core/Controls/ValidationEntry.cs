using Xamarin.Forms;

namespace Core.Controls
{
    public class ValidationEntry : Entry
    {
        public string ValidationError
        {
            get { return (string)GetValue (ValidationErrorProperty); }
            set { SetValue (ValidationErrorProperty, value); }
        }

        public static readonly BindableProperty ValidationErrorProperty = BindableProperty.Create (
                                                                              defaultBindingMode: BindingMode.TwoWay,
                                                                              propertyName: "ValidationError",
                                                                              returnType: typeof(string),
                                                                              declaringType: typeof(ValidationEntry),
                                                                              defaultValue: string.Empty);

        protected override SizeRequest OnSizeRequest (double widthConstraint, double heightConstraint)
        {
            return base.OnSizeRequest (widthConstraint, heightConstraint);
        }
    }
}