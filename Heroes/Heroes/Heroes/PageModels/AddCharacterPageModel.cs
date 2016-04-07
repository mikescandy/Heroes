using Heroes.Models;
using Heroes.PageModels;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;
using Core;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class AddCharacterPageModel : BaseCharacterPageModel
    {
        public AddCharacterPageModel (IRepository repository) : base (repository)
        {
        }

        public override void Init (object initData)
        {
            base.Init (initData);

            CancelCommand = new Command (async () => await CoreMethods.PopPageModel (null, true));

            SaveCommand = new MVVMCommand (async _ => {
                var character = new Character {
                    Alignment = Alignment,
                    CharacterClass = CharacterClass,
                    Charisma = Charisma,
                    Constitution = Constitution,
                    Dexterity = Dexterity,
                    Intelligence = Intelligence,
                    Name = Name,
                    Strength = Strength,
                    Wisdom = Wisdom
                };
                Repository.Add (character);
               
                await CoreMethods.PopPageModel (character.ID, true);
            }, _ => IsValid);
        }
    }
}