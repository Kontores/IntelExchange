using IntelExchange.DataModels;
using IntelExchange.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntelExchange.WebApi.Validation
{
    public abstract class BasicValidator<T> : IValidator<T>
    {
        protected readonly ModelStateDictionary _modelState;
        public BasicValidator(IActionContextAccessor actionContextAccessor)
        {
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public abstract Task ValidateAsync(T model);
        public abstract void Validate(T model);
    }
}
