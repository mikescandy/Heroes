using System;
using Heroes.Pages;
using Core.Pages;
using PropertyChanged;
using System.Windows.Input;
using Heroes.Services;
using Heroes.Validators;
using System.Reflection;
using System.Linq;
using Core;
using Heroes.Models;
using Xamarin.Forms;

namespace Heroes.PageModels
{
    [ImplementPropertyChanged]
    public class AddPartyPageModel : BasePageModel
    {
        protected readonly IRepository Repository;
        protected readonly PartyValidator Validator;

        [AlsoNotifyFor ("IsValid")]
        public string Name { get; set; }

        public string NameValidationError { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        protected AddPartyPageModel (IRepository repository)
        {
            Repository = repository;
            Validator = new PartyValidator ();
        }

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

        public override void Init (object initData)
        {
            base.Init (initData);

            CancelCommand = new Command (async () => await CoreMethods.PopPageModel ());

            SaveCommand = new MVVMCommand (
                async _ => {
                    var party = new Party {
                        Name = Name
                    };
                    Repository.Add (party);

                    await CoreMethods.PushPageModel <PartyPageModel> (party.ID);
                }, 
                _ => IsValid);
        }
    }
}

