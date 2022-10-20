using IntelExchange.DataModels.Enums;

namespace IntelExchange.DataModels
{
    public record struct Comission
        (
            Guid InstrumentId, 
            string Name,
            decimal Size,
            bool VolumeBased,
            ComissionPeriodicity Periodicity,
            decimal MinSize,
            decimal? MaxSize
        )
    {
        public decimal Calculate(decimal volume)
        {
            var comissionSize = VolumeBased ? Size * volume : Size;

            return comissionSize < MinSize
                ? MinSize
                : MaxSize.HasValue && comissionSize > MaxSize.Value 
                ? MaxSize.Value 
                : comissionSize;
        }
    }
}