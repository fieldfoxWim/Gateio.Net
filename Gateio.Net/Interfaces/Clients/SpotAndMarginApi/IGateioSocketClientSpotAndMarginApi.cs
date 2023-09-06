namespace Gateio.Net.Interfaces.Clients.SpotAndMarginApi;

public interface IGateioSocketClientSpotAndMarginApi
{
    /// <summary>
    /// Exchange data streams and queries
    /// </summary>
    IGateioSocketSpotApiExchangeData ExchangeData { get; }
}