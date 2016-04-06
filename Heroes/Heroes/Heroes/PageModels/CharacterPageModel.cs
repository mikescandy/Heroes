using System;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class CharacterPageModel : BasePageModel
    {
        private readonly IRepository _repository;

        public Character Character { get; set; }

        public CharacterPageModel (IRepository repository)
        {
            _repository = repository;
        }

        public override void Init (object initData)
        {
            try
            {
                var characterId = (int)initData;
                if (characterId > 0)
                {
                    Character = _repository.Get<Character> (characterId);
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
                _repository.Update (character);
                Character = _repository.Get<Character> (character.ID);
            }
        }
    }
}