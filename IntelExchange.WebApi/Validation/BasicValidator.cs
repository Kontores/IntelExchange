using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntelExchange.WebApi.Validation
{
    public abstract class BasicValidator<T> : IValidator<T>
    {
        protected readonly ModelStateDictionary _modelState;

        public BasicValidator(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        public abstract Task ValidateAsync(T model);
    }
}
