using FluentValidation;
using Heroes.PageModels;

namespace Heroes.Validators
{
    public class PartyValidator : AbstractValidator<AddPartyPageModel>
    {
        public PartyValidator ()
        {
            RuleFor (party => party.Name).NotEmpty ().WithMessage ("Enter the party name");
        }
    }
}