using IntelExchange.DataModels.Enums;

namespace IntelExchange.DataModels
{
    public record User
        (
        Guid Id, 
        string Login, 
        string Password,
        UserType Type
        )
    {
        public UserProfile Profile { get; init; }
        public Account Account { get; init; }
    }
}