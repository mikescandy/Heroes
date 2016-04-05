using System;
using System.Collections;
using Xamarin.Forms;

namespace Core.Controls
{
    public class BindablePicker : Picker
    {
        public BindablePicker ()
        {
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create (
                                                                          defaultBindingMode: BindingMode.TwoWay,
                                                                          propertyName: "ItemsSource",
                                                                          returnType: typeof(IEnumerable),
                                                                          declaringType: typeof(BindablePicker),
                                                                          propertyChanged: OnItemsSourceChanged,
                                                                          defaultValue: default(IEnumerable));

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create (
                                                                           defaultBindingMode: BindingMode.TwoWay,
                                                                           propertyName: "SelectedItem",
                                                                           returnType: typeof(object),
                                                                           declaringType: typeof(BindablePicker),
                                                                           propertyChanged: OnSelectedItemChanged,
                                                                           defaultValue: default(object));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue (ItemsSourceProperty); }
            set { SetValue (ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue (SelectedItemProperty); }
            set { SetValue (SelectedItemProperty, value); }
        }

        private static void OnItemsSourceChanged (BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var picker = bindable as BindablePicker;
            picker.Items.Clear ();
            if (newvalue != null)
            {
                // now it works like "subscribe once" but you can improve
                foreach (var item in newvalue)
                {
                    picker.Items.Add (item.ToString ());
                }
            }
        }

        private static void OnSelectedItemChanged (BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as BindablePicker;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.Items.IndexOf (newvalue.ToString ());
            }
        }

        private void OnSelectedIndexChanged (object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItem = Items [SelectedIndex];
            }
        }
    }
}