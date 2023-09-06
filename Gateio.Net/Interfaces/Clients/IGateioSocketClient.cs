using CryptoExchange.Net.Interfaces;
using Gateio.Net.Interfaces.Clients.PerpetualFutures;
using Gateio.Net.Interfaces.Clients.SpotAndMarginApi;

namespace Gateio.Net.Interfaces.Clients;

public interface IGateioSocketClient : ISocketClient
{
    /// <inheritdoc />
    IGateioSocketClientSpotAndMarginApi SpotAndMarginApi { get; set; }

    IGateioSocketClientPerpetualFuturesApi PerpetualFuturesApi { get; set; }
}