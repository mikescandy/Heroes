using Xamarin.Forms;

namespace Core.Validation
{
    public class ValidatableControl : ContentView, IValidatableControl
    {
        public string Identifier { get; set; }

        public Entry Entry { get; set; }

        public Label Message { get; set; }

        public bool HasError { get; set; }

        public ValidatableControl (string propertyName)
        {
            Identifier = propertyName;
            Entry = new Entry ();
            Message = new Label { IsVisible = false };

            var stackLayout = new StackLayout {
                Orientation = StackOrientation.Vertical,
                Children = {
                    Entry,
                    Message
                }
            };

            Content = stackLayout;
        }

        public void SetEntryTextBinding (string propertyName)
        {
            Entry.SetBinding (Entry.TextProperty, propertyName);
        }

        public void SetMessage (string message)
        {
            Message.Text = message;

            HasError = true;

            Message.IsVisible = true;
        }

        public void SetMessageColor (Color color)
        {
            Message.TextColor = color;
        }

        public void Clear ()
        {
            HasError = false;
            Message.Text = string.Empty;
            Message.TextColor = Color.Default;
        }
    }
}