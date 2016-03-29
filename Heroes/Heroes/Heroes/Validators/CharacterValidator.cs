using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Heroes.Validators
{
	public class CharacterValidator : AbstractValidator<EditCharacterPageModel>
    {
        public CharacterValidator()
        {
            RuleFor(character => character.Name).NotEmpty().WithMessage("Enter the character name");
        }
    }
}
