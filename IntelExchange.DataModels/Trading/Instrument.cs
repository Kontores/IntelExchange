namespace IntelExchange.DataModels
{
    public record Instrument
    (
        Guid Id,
        string Ticker,
        decimal Volume,
        decimal TickSize,
        decimal TickPrice,
        decimal MarginRequirement
    )
    {
        public List<Comission> Comissions { get; init; }
    }
}