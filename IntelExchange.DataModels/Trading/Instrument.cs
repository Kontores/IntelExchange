namespace IntelExchange.DataModels
{
    public record Instrument
    (
        Guid Id,
        string Ticker,
        decimal Volume
    );
}