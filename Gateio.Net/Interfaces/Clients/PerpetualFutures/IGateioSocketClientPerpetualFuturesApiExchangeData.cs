using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Gateio.Net.Enums;
using Gateio.Net.Objects.@internal;
using Gateio.Net.Objects.Models.Futures;

namespace Gateio.Net.Interfaces.Clients.PerpetualFutures;

public interface IGateioSocketClientPerpetualFuturesApiExchangeData
{
    /// <inheritdoc />
    Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(FuturesContractSettle settle, string symbol, Action<DataEvent<GateioSocketResponse<List<GateioFutureTick>>>> onMessage, CancellationToken ct = default);

    /// <inheritdoc />
    Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(FuturesContractSettle settle, IEnumerable<string> symbols, Action<DataEvent<GateioSocketResponse<List<GateioFutureTick>>>> onMessage, CancellationToken ct = default);

    Task<CallResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(FuturesContractSettle settle, string symbol,Action<DataEvent<GateioSocketResponse<GateioFutureBookTick>>> onMessage, CancellationToken ct = default);

    Task<CallResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(FuturesContractSettle settle,
        IEnumerable<string> symbols, Action<DataEvent<GateioSocketResponse<GateioFutureBookTick>>> onMessage,
        CancellationToken ct = default);
}