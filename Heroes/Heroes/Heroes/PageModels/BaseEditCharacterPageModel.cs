﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Core;
using Core.Pages;
using Heroes.Models;
using Heroes.Services;
using Heroes.Validators;
using PropertyChanged;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public abstract class BaseEditCharacterPageModel : BasePageModel
    {
        protected readonly IRepository Repository;
        protected readonly CharacterValidator Validator;

        [AlsoNotifyFor ("IsValid")]
        public string Name { get; set; }

        public string NameValidationError { get; set; }

        [AlsoNotifyFor ("IsValid")]
        public CharacterClass CharacterClass { get; set; }

        [AlsoNotifyFor ("IsValid")]
        public string Alignment { get; set; }

        public uint Level { get; set; }

        public uint Experience { get; set; }

        [AlsoNotifyFor ("IsValid")]
        public uint Strength { get; set; }

        [AlsoNotifyFor ("IsValid")]
        public uint Dexterity { get; set; }

        [AlsoNotifyFor ("IsValid")]
        public uint Constitution { get; set; }

        [AlsoNotifyFor ("IsValid")]
        public uint Intelligence { get; set; }

        [AlsoNotifyFor ("IsValid")]
        public uint Wisdom { get; set; }

        [AlsoNotifyFor ("IsValid")]
        public uint Charisma { get; set; }

        public int MaxHP { get; set; }

        public ObservableCollection<string> Alignments { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }

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
                    var validationProperty = this.GetType ().GetTypeInfo ().GetAllProperties ().FirstOrDefault (m => m.Name == result.PropertyName + "ValidationError");
                    if (validationProperty != null)
                    {
                        validationProperty.SetValue (this, result.ErrorMessage);
                        RaisePropertyChanged (validationProperty.Name);
                    }
                }

                return false;
            }
        }

        protected BaseEditCharacterPageModel (IRepository repository)
        {
            Alignments = new ObservableCollection<string> (Enum.GetNames (typeof(Alignment)).ToList ());
            Repository = repository;
            Validator = new CharacterValidator ();
        }
    }
}