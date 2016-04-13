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
    public class CharacterPageModel : BasePageModel
    {
        private readonly IRepository repository;

        public Character Character { get; set; }

        public ICommand EditCommand { get; set; }

        public CharacterPageModel (IRepository repository)
        {
            this.repository = repository;
        }

        public override void Init (object initData)
        {
            EditCommand = new Command (async () => await CoreMethods.PushPageModel<EditCharacterPageModel> (Character.ID, true));
            try
            {
                var characterId = (int)initData;
                if (characterId > 0)
                {
                    Character = repository.Get<Character> (characterId);
                }
            }
            catch (InvalidCastException ex)
            {
            }
        }

        public override void ReverseInit (object returndData)
        {
            var character = returndData as Character;
            if (character != null)
            {
                repository.Update (character);
                Character = repository.Get<Character> (character.ID);
            }
        }
    }
}