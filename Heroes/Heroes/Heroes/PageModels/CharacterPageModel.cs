using FreshMvvm;
 
using PropertyChanged;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class CharacterPageModel : FreshBasePageModel
    {
        public Character Character { get; set; }
        public CharacterPageModel()
        {
            Character = new Character() { Name = "Pippo", CharacterClass = CharacterClass.Fighter, Experience = 1, Level = 2, Strength = 15 };
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

