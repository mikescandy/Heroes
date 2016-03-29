using Core.Services;
using FreshMvvm;
using Heroes.Services;
using PropertyChanged;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class CharacterPageModel : BasePageModel
    {
        private readonly IRepository _repository;
        private readonly IValidationService _validationService;
        public Character Character { get; set; }


        public CharacterPageModel(IRepository repository/*, IValidationService validationService*/)
        {
            _repository = repository;
            //_validationService = validationService;
            Character = _repository.GetLatest<Character>();
        }

        public override void ReverseInit(object returndData)
        {
            var character = returndData as Character;
            if (character != null)
            {
                _repository.Update(character);
                Character = _repository.Get<Character>(character.ID);
            }
        }

       /* public bool IsValid
        {
            get
            {
                var validationResult = _validationService.Validate(this);
                return validationResult.IsValid;
            }
        }*/

        //public Command ShowQuotes {
        //    get {
        //        return new Command (async () => {
        //            await CoreMethods.PushPageModel<QuoteListPageModel> ();
        //        });
        //    }
        //}

        //public Command ShowContacts {
        //    get {
        //        return new Command (async () => {
        //            await CoreMethods.PushPageModel<ContactListPageModel> ();
        //        });
        //    }
        //}
    }
}

