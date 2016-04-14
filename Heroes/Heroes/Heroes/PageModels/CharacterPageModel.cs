using System;
using System.Windows.Input;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public sealed class CharacterPageModel : BaseCharacterPageModel
    {
        public ICommand EditCommand { get; set; }

        public CharacterPageModel(IRepository repository) : base(repository)
        {
        }

        public override void Init(object initData)
        {
            base.Init (initData);
            EditCommand = new Command(async () => await CoreMethods.PushPageModel<EditCharacterPageModel>(Character.ID, true));
        }

        public override void ReverseInit(object returndData)
        {
            var character = returndData as Character;
            if (character != null)
            {
                Repository.Update(character);
                Character = Repository.Get<Character>(character.ID);
            }
        }
    }
}