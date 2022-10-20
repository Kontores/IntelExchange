using IntelExchange.DataModels.Enums;

namespace IntelExchange.DataModels
{
    public record Strategy
    (
        Guid Id,      
        string Name,
        string Description,
        string Script
    );
}