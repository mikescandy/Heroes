using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Core.Behaviors
{
    public class MinMaxNumericValidationBehavior : Behavior<Entry>
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public bool IsValid { get; set; }

        public MinMaxNumericValidationBehavior()
        {
            Min = double.MinValue;
            Max = double.MaxValue;
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            double result;
            IsValid = Double.TryParse(args.NewTextValue, out result);
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
