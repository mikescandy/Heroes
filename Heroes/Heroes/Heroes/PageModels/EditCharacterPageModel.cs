using System;
using Heroes;
using Heroes.Models;
using Heroes.PageModels;
using Heroes.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class EditCharacterPageModel : BaseCharacterPageModel
    {
        public EditCharacterPageModel (IRepository repository) : base (repository)
        {
        }

        public override void Init (object initData)
        {
            base.Init (initData);
            var characterId = (int)initData;
            App.Mapper.Map (Repository.Get<Character> (characterId), this);

            CancelCommand = new Command (async () => {
                await CoreMethods.PopPageModel (null, true);
            });

            SaveCommand = new Command (async () => {
                await CoreMethods.PopPageModel (this, true);
            });
        }

        public override void ReverseInit (object returndData)
        {
            base.ReverseInit (returndData);
        }
    }
}