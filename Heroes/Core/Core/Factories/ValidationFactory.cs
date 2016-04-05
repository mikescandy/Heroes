using System;
using System.Reflection;
using FluentValidation;
using FreshMvvm;

namespace Core.Factories
{
    public class FluentValidatorFactory : IValidatorFactory
    {
        public IValidator<T> GetValidator<T> ()
        {
            return (IValidator<T>)this.GetValidator (typeof(T));
        }

        public IValidator GetValidator (Type type)
        {
            IValidator validator;

            try
            {
                // Obtain instance of validator. If not registered, SimpleIoc will throw exception (although documentation said it will return null)
                validator = this.CreateInstance (typeof(IValidator<>).MakeGenericType (type));
            }
#pragma warning disable 0168
            catch (Exception exception)
#pragma warning restore 0168
            {
                // Get base type and try to find validator for base type (used for polymorphic classes)
                var baseType = type.GetTypeInfo ().BaseType;
                if (baseType == null)
                {
                    throw;
                }

                validator = this.CreateInstance (typeof(IValidator<>).MakeGenericType (baseType));
            }

            return validator;
        }

        public IValidator CreateInstance (Type validatorType)
        {
            return FreshIOC.Container.Resolve<IValidator> ();
        }
    }
}