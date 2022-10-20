using IntelExchange.DataModels.Enums;

namespace IntelExchange.DataModels
{
    public record Order
    (
        Guid Id,
        Guid TraderId,
        Guid InstrumentId,
        OrderType Type,
        OrderStatus Status,
        TradeDirection Direction,
        decimal Price,
        decimal Volume,
        decimal FilledVolume
    )
    {
        public IEnumerable<Deal> Deals { get; init; }
    }
}