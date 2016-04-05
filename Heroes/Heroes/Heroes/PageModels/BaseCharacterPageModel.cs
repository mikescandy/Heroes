using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using Heroes.Validators;
using PropertyChanged;

namespace Heroes.PageModels
{
    public abstract class BaseCharacterPageModel : BasePageModel
    {
        protected readonly IRepository Repository;
        protected readonly CharacterValidator Validator;

        public string Name { get; set; }

        public string NameValidationError { get; set; }

        public CharacterClass CharacterClass { get; set; }

        public Alignment Alignment { get; set; }

        public uint Level { get; set; }

        public uint Experience { get; set; }

        public uint Strength { get; set; }

        public uint Dexterity { get; set; }

        public uint Constitution { get; set; }

        public uint Intelligence { get; set; }

        public uint Wisdom { get; set; }

        public uint Charisma { get; set; }

        public int MaxHP { get; set; }

        public ObservableCollection<string> Alignments { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        [DependsOn ("Name")]
        public bool IsValid
        {
            get {
                var validationResult = Validator.Validate (this);
                if (validationResult.IsValid)
                {
                    foreach (var property in this.GetType().GetTypeInfo().DeclaredProperties.Where(m => m.Name.EndsWith("ValidationError")).ToList())
                    {
                        property.SetValue (this, string.Empty);
                        RaisePropertyChanged (property.Name);
                    }

                    return true;
                }

                foreach (var result in validationResult.Errors)
                {
                    var validationProperty = this.GetType ().GetTypeInfo ().GetDeclaredProperty (result.PropertyName + "ValidationError");
                    if (validationProperty != null)
                    {
                        validationProperty.SetValue (this, result.ErrorMessage);
                        RaisePropertyChanged (validationProperty.Name);
                    }
                }

                return true;
            }
        }

        protected BaseCharacterPageModel (IRepository repository)
        {
            Alignments = new ObservableCollection<string> (Enum.GetNames (typeof(Alignment)).ToList ());
            Repository = repository;
            Validator = new CharacterValidator ();
        }
    }
}