namespace IntelExchange.DataModels
{
    public abstract record UserProfile
    (
        Guid UserId,
        string Email,
        string PhoneNumber
    );

    public record IndividualProfile
    (
    Guid UserId,
    string Email,
    string PhoneNumber,
    string FirstName,
    string LastName,
    string Address
    ) : UserProfile(UserId, Email, PhoneNumber);

    public record CompanyProfile
    (
    Guid UserId,
    string Email,
    string PhoneNumber,
    string CompanyName,
    string CompanyForm,
    string PostAddress,
    string ITIN
    ) : UserProfile(UserId, Email, PhoneNumber);
}