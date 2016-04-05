using Xamarin.Forms;

namespace Core.Behaviors
{
    public class MinMaxNumericValidationBehavior : Behavior<Entry>
    {
        public double Min { get; set; }

        public double Max { get; set; }

        public bool IsValid { get; set; }

        public MinMaxNumericValidationBehavior ()
        {
            Min = double.MinValue;
            Max = double.MaxValue;
        }

        /// <inheritdoc />
        protected override void OnAttachedTo (Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo (bindable);
        }

        /// <inheritdoc />
        protected override void OnDetachingFrom (Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom (bindable);
        }

        private void OnEntryTextChanged (object sender, TextChangedEventArgs args)
        {
            double result;
            IsValid = double.TryParse (args.NewTextValue, out result);
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
