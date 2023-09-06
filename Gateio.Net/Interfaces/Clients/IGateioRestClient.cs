using Gateio.Net.Interfaces.Clients.PerpetualFutures;
using Gateio.Net.Interfaces.Clients.SpotAndMarginApi;

namespace Gateio.Net.Interfaces.Clients;

public interface IGateioRestClient
{
    /// <summary>
    /// Spot and Margin API endpoints
    /// </summary>
    IGateioRestClientSpotAndMarginApi SpotAndMarginApi { get; }

    /// <summary>
    /// Usd futures API endpoints
    /// </summary>
    IGateioRestClientPerpetualFuturesApi PerpetualFuturesApi { get; }
}