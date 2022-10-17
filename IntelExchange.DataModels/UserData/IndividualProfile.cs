namespace IntelExchange.DataModels
{
    public record IndividualProfile
        (
        Guid UserId, 
        string Email, 
        string FirstName, 
        string LastName
        ) : UserProfile(UserId, Email);
}