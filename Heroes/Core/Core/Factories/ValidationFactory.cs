using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FreshMvvm;
using Xamarin.Forms;

namespace Core.Factories
{
    public class FluentValidatorFactory : IValidatorFactory
    {
        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)this.GetValidator(typeof(T));
        }

        public IValidator GetValidator(Type type)
        {
            IValidator validator;

            try
            {
                // Obtain instance of validator. If not registered, SimpleIoc will throw exception (although documentation said it will return null)
                validator = this.CreateInstance(typeof(IValidator<>).MakeGenericType(type));
            }
            catch (Exception exception)
            {
                // Get base type and try to find validator for base type (used for polymorphic classes)
                var baseType = type.GetTypeInfo().BaseType;
                if (baseType == null)
                {
                    throw;
                }

                validator = this.CreateInstance(typeof(IValidator<>).MakeGenericType(baseType));
            }

            return validator;
        }

        public IValidator CreateInstance(Type validatorType)
        {
            return FreshIOC.Container.Resolve<IValidator>();
        }
    }


}
