namespace IntelExchange.DataModels
{
    // Deal record represents transaction between buyer and seller, i.e. when 
    // selling limit order is filled/partially filled with counterparty market buying order
    public record Deal
        (
            Guid Id,
            Guid SaleOrderId,
            Guid BuyOrderId,
            decimal Price,
            decimal Volume
        );
}