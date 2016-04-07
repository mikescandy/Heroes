using System;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class CharacterPageModel : BasePageModel
    {
        private readonly IRepository repository;

        public Character Character { get; set; }

        public CharacterPageModel (IRepository repository)
        {
            this.repository = repository;
        }

        public override void Init (object initData)
        {
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