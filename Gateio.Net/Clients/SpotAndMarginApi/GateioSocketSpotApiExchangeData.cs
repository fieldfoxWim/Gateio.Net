using System.Globalization;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Gateio.Net.Interfaces.Clients.SpotAndMarginApi;
using Gateio.Net.Objects.@internal;
using Gateio.Net.Objects.Models.Spot;
using Microsoft.Extensions.Logging;

namespace Gateio.Net.Clients.SpotAndMarginApi;

public class GateioSocketSpotApiExchangeData : IGateioSocketSpotApiExchangeData
{
    private const string version = "4";
    private readonly ILogger _logger;
    private readonly GateioSocketSpotAndMarginApi _client;
    
    #region constructor/destructor

    internal GateioSocketSpotApiExchangeData(ILogger logger, GateioSocketSpotAndMarginApi client)
    {
        _client = client;
        _logger = logger;
    }

    #endregion
    
    #region Individual Symbol Ticker Streams

    /// <inheritdoc />
    public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<GateioSocketResponse<GateioTick>>> onMessage, CancellationToken ct = default) => await SubscribeToTickerUpdatesAsync(new[] { symbol }, onMessage, ct).ConfigureAwait(false);

    /// <inheritdoc />
    public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<GateioSocketResponse<GateioTick>>> onMessage, CancellationToken ct = default)
    {
        symbols.ValidateNotNull(nameof(symbols));
        foreach (var symbol in symbols)
            symbol.ValidateGateioSymbol();

        
        var handler = new Action<DataEvent<GateioSocketResponse<GateioTick>>>(data => onMessage(data.As(data.Data, data.Data.Result.CurrencyPair)));
        return await _client.SubscribeAsync(_client.BaseAddress.AppendPath($"v{version}")+"/", "spot.tickers", symbols, handler, ct).ConfigureAwait(false);
    }

    #endregion
}