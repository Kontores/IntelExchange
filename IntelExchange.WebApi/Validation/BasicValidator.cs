using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntelExchange.WebApi.Validation
{
    public abstract class BasicValidator<T>
    {
        protected readonly ModelStateDictionary _modelState;
        public BasicValidator(IActionContextAccessor actionContextAccessor)
        {
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
    }
}
