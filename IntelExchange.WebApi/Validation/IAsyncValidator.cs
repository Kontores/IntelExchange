namespace IntelExchange.WebApi.Validation
{
    public interface IAsyncValidator<T>
    {
        Task ValidateAsync(T model);
    }
}
