namespace IntelExchange.DataModels
{
    public abstract record UserProfile
    (
        Guid UserId,
        string Email
    );
}