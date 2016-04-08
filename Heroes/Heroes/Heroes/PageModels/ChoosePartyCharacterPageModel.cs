using System.Windows.Input;
using Core.Pages;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    public class ChoosePartyCharacterPageModel : BasePageModel
    {
        public ICommand CancelCommand { get; set; }

        public ICommand ChoosePartyCommand { get; set; }

        public ICommand ChooseCharacterCommand { get; set; }

        public ChoosePartyCharacterPageModel ()
        {
        }

        public override void Init (object initData)
        {
            CancelCommand = new Command (async () => await CoreMethods.PopPageModel ());
           
            ChoosePartyCommand = new Command (async () => await CoreMethods.PushPageModel<AddCharacterPageModel> ());

            ChooseCharacterCommand = new Command (async () => await CoreMethods.PushPageModel<AddCharacterPageModel> ());
        }
    }
}