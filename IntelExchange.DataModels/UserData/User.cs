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
        public IEnumerable<UserRole> Roles { get; init; }
        public Trader? TradingProfile { get; init; }
    }
}