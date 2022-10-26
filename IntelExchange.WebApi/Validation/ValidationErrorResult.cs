using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntelExchange.WebApi.Validation
{
    public record ValidationErrorResult
    {
        public string Name { get; init; }

        public Dictionary<string, string> Errors { get; init; }
        
        public ValidationErrorResult(ModelStateDictionary modelState)
        {
            Name = "Validation Error";
            Errors = modelState.Keys.ToDictionary(key => key, key => modelState.GetValueOrDefault(key).Errors.Single().ErrorMessage);
        }
    }
}
