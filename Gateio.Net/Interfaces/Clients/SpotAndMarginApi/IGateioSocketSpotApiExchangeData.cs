using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Gateio.Net.Objects.@internal;
using Gateio.Net.Objects.Models.Spot;

namespace Gateio.Net.Interfaces.Clients.SpotAndMarginApi;

public interface IGateioSocketSpotApiExchangeData
{
    /// <inheritdoc />
    Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<GateioSocketResponse<GateioTick>>> onMessage, CancellationToken ct = default);

    /// <inheritdoc />
    Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<GateioSocketResponse<GateioTick>>> onMessage, CancellationToken ct = default);
}