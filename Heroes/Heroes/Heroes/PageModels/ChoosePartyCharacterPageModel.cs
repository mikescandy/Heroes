using System.Windows.Input;
using Core.Pages;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    public class ChoosePartyCharacterPageModel : TransientPageModel
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
           
            ChoosePartyCommand = new Command (async () => await CoreMethods.PushPageModel<AddPartyPageModel>());

            ChooseCharacterCommand = new Command (async () => await CoreMethods.PushPageModel<AddCharacterPageModel> ());
        }
    }
}