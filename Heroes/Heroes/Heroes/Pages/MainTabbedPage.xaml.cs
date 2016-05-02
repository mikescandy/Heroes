using Core.Controls;
using Xamarin.Forms.Xaml;

namespace Heroes.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : CustomTabbedPage
    {
        public MainTabbedPage ()
        {
            InitializeComponent ();
        }
    }
}