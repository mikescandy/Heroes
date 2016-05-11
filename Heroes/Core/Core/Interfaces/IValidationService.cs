using FluentValidation.Results;

namespace Core.Services
{
    public interface IValidationService
    {
        ValidationResult Validate<T> (T entity) where T : class;
    }
}