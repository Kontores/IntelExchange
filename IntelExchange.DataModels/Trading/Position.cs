using IntelExchange.DataModels.Enums;

namespace IntelExchange.DataModels
{
    public record Position
    {
        public Guid UserId; 
        public Guid InstrumentId; 
        public DateTime EntryDate; 
        public TradeDirection Direction; 
        public decimal EntryPrice; 
        public decimal Volume;
        public decimal VariableMargin(decimal currentPrice) => Direction == TradeDirection.Long
            ? Volume * (currentPrice - EntryPrice)
            : Volume * (EntryPrice - currentPrice);

        public Instrument Instrument;
    }
}