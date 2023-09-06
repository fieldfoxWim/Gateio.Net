using CryptoExchange.Net.Interfaces.CommonClients;

namespace Gateio.Net.Interfaces.Clients.PerpetualFutures;

public interface IGateioRestClientPerpetualFuturesApi
{
    /// <summary>
    /// Endpoints related to retrieving market and system data
    /// </summary>
    public IGateioRestClientPerpetualFuturesApiExchangeData ExchangeData { get; }
    
    /// <summary>
    /// Get the IFuturesClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.
    /// </summary>
    /// <returns></returns>
    public IFuturesClient CommonFuturesClient { get; }
}