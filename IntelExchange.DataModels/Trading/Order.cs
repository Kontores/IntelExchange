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
        public Instrument? Instrument { get; init; }
        public List<Guid> CounterPartyOrderIds { get; init; } = new List<Guid>();
    }
}