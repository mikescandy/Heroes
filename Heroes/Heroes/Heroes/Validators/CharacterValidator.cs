using FluentValidation;
using Heroes.PageModels;

namespace Heroes.Validators
{
    public class CharacterValidator : AbstractValidator<BaseEditCharacterPageModel>
    {
        public CharacterValidator()
        {
            RuleFor(character => character.Name).NotEmpty().WithMessage("Enter the character name");
            RuleFor(character => character.Alignment).Must(value => value > 0).WithMessage("Please select and alignment");
            RuleFor(character => character.Strength).Must(value => value >= 3).WithMessage("Attributes must be greater than 0");
            RuleFor(character => character.Constitution).Must(value => value >= 3).WithMessage("Attributes must be greater than 0");
            RuleFor(character => character.Dexterity).Must(value => value >= 3).WithMessage("Attributes must be greater than 0");
            RuleFor(character => character.Wisdom).Must(value => value >= 3).WithMessage("Attributes must be greater than 0");
            RuleFor(character => character.Intelligence).Must(value => value >= 3).WithMessage("Attributes must be greater than 0");
            RuleFor(character => character.Charisma).Must(value => value >= 3).WithMessage("Attributes must be greater than 0");
        }
    }
}