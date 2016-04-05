using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Validation;
using FluentValidation;
using Xamarin.Forms;

namespace Core.Pages
{
    public abstract class ValidatorPage<T, TValidator> : ContentPage where TValidator : IValidator, new() where T : class, new()
    {
        public IBasePageModel Model { get; set; }

        private readonly HashSet<IValidatableControl> validatableElements = new HashSet<IValidatableControl> ();

        protected void ResolveValidatableElements ()
        {
            var properties = this.GetType ().GetTypeInfo ().DeclaredProperties.Where (m => m.GetType () == typeof(ValidatableControl));
        }
    }
}