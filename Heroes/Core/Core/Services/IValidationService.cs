using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Core.Services
{
    public interface IValidationService
    {
        ValidationResult Validate<T>(T entity) where T : class;
    }

}
