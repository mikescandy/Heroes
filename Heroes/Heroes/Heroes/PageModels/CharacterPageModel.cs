using FreshMvvm;
using Heroes.Services;
using PropertyChanged;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class CharacterPageModel : FreshBasePageModel
    {
        private readonly IRepository _repository;
        public Character Character { get; set; }


        public CharacterPageModel(IRepository repository)
        {
            _repository = repository;
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

