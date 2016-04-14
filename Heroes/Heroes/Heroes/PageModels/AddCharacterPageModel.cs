using System;
using Core;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class AddCharacterPageModel : BaseCharacterPageModel
    {
        public int PartyId { get; set; }

        public AddCharacterPageModel(IRepository repository) : base(repository)
        {
            Title = "New Character";
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            if (initData != null)
            {
                try
                {
                    PartyId = (int)initData;
                }
                catch (InvalidCastException ex)
                {
                    System.Diagnostics.Debug.WriteLine("This should not happen.", ex.Message);
                }
            }

            CancelCommand = new Command(async () => await CoreMethods.PopPageModel());

            SaveCommand = new MVVMCommand(
                async _ =>
                {
                    var character = new Character
                    {
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

                    if (PartyId > default(int))
                    {
                        character.PartyId = PartyId;
                    }

                    Repository.Add(character);

                    await CoreMethods.PushPageModel<MainTabbedPageModel>(character.ID);
                },
                _ => IsValid);
        }
    }
}