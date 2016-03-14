using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FreshMvvm;
using Heroes;
using Heroes.Models;
using Heroes.Services;
using PropertyChanged;

namespace Heroes
{
    [ImplementPropertyChanged]
    public class EditCharacterPageModel : FreshBasePageModel
    {
        private readonly IRepository _repository;
        public Character Character { get; set; }
        public ObservableCollection<string> Alignments { get; set; }
        public EditCharacterPageModel(IRepository repository)
        {
            Alignments = new ObservableCollection<string>(Enum.GetNames(typeof(Alignment)).ToList());
            _repository = repository;
        }

        public override void Init(object initData)
        {
            var characterId = (int)initData;
            Character = _repository.Get<Character>(characterId);
        }

        public override void ReverseInit(object returndData)
        {
            base.ReverseInit(returndData);
        }
    }
}
