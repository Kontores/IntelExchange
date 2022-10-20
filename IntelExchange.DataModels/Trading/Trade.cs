using IntelExchange.DataModels.Enums;

namespace IntelExchange.DataModels
{
    public record Trade
    (
        Guid UserId,
        Guid InstrumentId,
        DateTime EntryDate,
        DateTime ExitDate,
        TradeDirection Direction,
        decimal EntryPrice,
        decimal ExitPrice,
        decimal Volume
    )
    {    
        public decimal Result() => Direction == TradeDirection.Long 
            ? Volume * (ExitPrice - EntryPrice) 
            : Volume * (EntryPrice - ExitPrice);
    }
}