using System;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public abstract class BaseCharacterPageModel : BasePageModel
    {
        public Character Character { get; set; }

        protected readonly IRepository Repository;

        public BaseCharacterPageModel (IRepository repository)
        {
            Repository = repository;
        }

        public override void Init (object initData)
        {
            base.Init (initData);
            if (initData == null) return;
            try {
                var characterId = (int)initData;
                if (characterId > 0) {
                    Character = Repository.Get<Character> (characterId);
                    //Title = Character.Name;
                }
            } catch (InvalidCastException ex) {
                System.Diagnostics.Debug.WriteLine ("This should not happen.", ex.Message);
            }
        }
    }
}