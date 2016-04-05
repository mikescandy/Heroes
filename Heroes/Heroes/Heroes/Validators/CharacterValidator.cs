using FluentValidation;
using Heroes.PageModels;

namespace Heroes.Validators
{
    public class CharacterValidator : AbstractValidator<BaseCharacterPageModel>
    {
        public CharacterValidator ()
        {
            RuleFor (character => character.Name).NotEmpty ().WithMessage ("Enter the character name");
        }
    }
}
