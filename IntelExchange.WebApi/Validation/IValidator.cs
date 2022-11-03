namespace IntelExchange.WebApi.Validation
{
    public interface IValidator<T>
    {
        void Validate(T model);
    }
}
