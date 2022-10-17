namespace IntelExchange.DataModels
{
    public record CompanyProfile
        (
        Guid UserId, 
        string Email, 
        string CompanyName, 
        string CompanyForm,
        string PostAddress,
        string ITIN
        ) : UserProfile(UserId, Email);
}