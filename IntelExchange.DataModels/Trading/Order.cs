using IntelExchange.DataModels.Enums;

namespace IntelExchange.DataModels
{
    public record Order
    (
        Guid Id,
        Guid InitiatorId,
        Guid InstrumentId,
        OrderType Type,
        OrderStatus Status,
        TradeDirection Direction,
        decimal Price,
        decimal Volume,
        decimal FilledVolume
    )
    {
        public List<Deal> Deals { get; init; } = new List<Deal>();
    }
}