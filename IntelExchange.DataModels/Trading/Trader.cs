using IntelExchange.DataModels.Enums;

namespace IntelExchange.DataModels
{
    public record Trader
    (
        Guid Id,      
        string Name,
        TraderType Type,
        Guid? UserId
    )
    {
        public TradingAccount Account { get; init; }
        public List<Strategy> Strategies { get; init; }
    }
}