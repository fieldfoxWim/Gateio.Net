using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Gateio.Net.Clients.SpotAndMarginApi;
using Gateio.Net.Enums;
using Gateio.Net.Interfaces.Clients.PerpetualFutures;
using Gateio.Net.Objects.@internal;
using Gateio.Net.Objects.Models.Futures;
using Gateio.Net.Objects.Models.Spot;
using Microsoft.Extensions.Logging;

namespace Gateio.Net.Clients.PerpetualFuturesApi;

public class GateioSocketClientPerpetualFuturesApiExchangeData : IGateioSocketClientPerpetualFuturesApiExchangeData
{
    private const string version = "4";
    private readonly ILogger _logger;
    private readonly GateioSocketClientPerpetualFuturesApi _client;
    
    #region constructor/destructor

    internal GateioSocketClientPerpetualFuturesApiExchangeData(ILogger logger, GateioSocketClientPerpetualFuturesApi client)
    {
        _client = client;
        _logger = logger;
    }

    #endregion
    
    #region Individual Symbol Ticker Streams

    /// <inheritdoc />
    public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(FuturesContractSettle settle, string symbol, Action<DataEvent<GateioSocketResponse<List<GateioFutureTick>>>> onMessage, CancellationToken ct = default) => await SubscribeToTickerUpdatesAsync(settle, new[] { symbol }, onMessage, ct).ConfigureAwait(false);

    /// <inheritdoc />
    public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(FuturesContractSettle settle, IEnumerable<string> symbols, Action<DataEvent<GateioSocketResponse<List<GateioFutureTick>>>> onMessage, CancellationToken ct = default)
    {
        symbols.ValidateNotNull(nameof(symbols));
        foreach (var symbol in symbols)
            symbol.ValidateGateioSymbol();
        
        var baseAddress = _client.BaseAddress.AppendPath($"v{version}").AppendPath("ws")
            .AppendPath(EnumConverter.GetString(settle));
        var handler = new Action<DataEvent<GateioSocketResponse<List<GateioFutureTick>>>>(data => onMessage(data.As(data.Data, data.Data.Result.ToString())));
        return await _client.SubscribeAsync(baseAddress, "futures.tickers", symbols, handler, ct).ConfigureAwait(false);
    }

    #endregion
    
    #region Book Ticker
    
    public async Task<CallResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(FuturesContractSettle settle, string symbol,Action<DataEvent<GateioSocketResponse<GateioFutureBookTick>>> onMessage, CancellationToken ct = default) => await SubscribeToBookTickerUpdatesAsync(settle, new[] { symbol }, onMessage, ct).ConfigureAwait(false);

    public async Task<CallResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(FuturesContractSettle settle,
        IEnumerable<string> symbols, Action<DataEvent<GateioSocketResponse<GateioFutureBookTick>>> onMessage,
        CancellationToken ct = default)
    {
        symbols.ValidateNotNull(nameof(symbols));
        foreach (var symbol in symbols)
            symbol.ValidateGateioSymbol();
        
        var baseAddress = _client.BaseAddress.AppendPath($"v{version}").AppendPath("ws")
            .AppendPath(EnumConverter.GetString(settle));
        var handler = new Action<DataEvent<GateioSocketResponse<GateioFutureBookTick>>>(data => onMessage(data.As(data.Data, data.Data.Result.ToString())));
        return await _client.SubscribeAsync(baseAddress, "futures.book_ticker", symbols, handler, ct).ConfigureAwait(false);
    }
    
    #endregion
}