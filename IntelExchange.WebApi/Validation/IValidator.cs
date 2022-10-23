namespace IntelExchange.WebApi.Validation
{
    public interface IValidator<T>
    {
        Task ValidateAsync(T model);
    }
}
