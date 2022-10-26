using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntelExchange.WebApi.Validation
{
    public interface IValidator<T>
    {
        Task ValidateAsync(T model);
        void Validate(T model);
    }
}
