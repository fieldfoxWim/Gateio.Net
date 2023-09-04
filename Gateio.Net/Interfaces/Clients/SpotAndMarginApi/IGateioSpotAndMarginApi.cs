using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;

namespace Gateio.Net.Interfaces.Clients.SpotAndMarginApi;

public interface IGateioRestClientSpotAndMarginApi : IRestApiClient, IDisposable
{
    /// <summary>
    /// Endpoints related to retrieving market and system data
    /// </summary>
    public IGateioRestClientSpotApiExchangeData ExchangeData { get; }
    
    /// <summary>
    /// Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.
    /// </summary>
    /// <returns></returns>
    public ISpotClient CommonSpotClient { get; }
}