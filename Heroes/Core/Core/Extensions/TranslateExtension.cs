using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Core
{
    // You exclude the 'Extension' suffix when using in Xaml markup
    [ContentProperty ("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private const string ResourceId = "Heroes.AppResources";
        private readonly CultureInfo ci;

        public TranslateExtension ()
        {
            ci = DependencyService.Get<ILocalize> ().GetCurrentCultureInfo ();
        }

        public string Text { get; set; }

        public object ProvideValue (IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return string.Empty; 
            }  

            var temp = new ResourceManager (
                           ResourceId,
                           typeof(TranslateExtension).GetTypeInfo ().Assembly);

            var translation = temp.GetString (Text, ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException (
                    string.Format ("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name), "Text");
#else
            translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }

            return translation;
        }
    }

    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo ();

        void SetLocale ();
    }
}