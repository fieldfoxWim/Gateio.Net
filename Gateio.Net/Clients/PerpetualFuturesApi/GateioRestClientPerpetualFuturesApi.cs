using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using Gateio.Net.Enums;
using Gateio.Net.Interfaces.Clients.PerpetualFutures;
using Gateio.Net.Objects.Options;
using Microsoft.Extensions.Logging;

namespace Gateio.Net.Clients.PerpetualFuturesApi;

public class GateioRestClientPerpetualFuturesApi : RestApiClient, IGateioRestClientPerpetualFuturesApi, IFuturesClient
{
    #region fields 
    /// <inheritdoc />
    public new GateioRestApiOptions ApiOptions => (GateioRestApiOptions)base.ApiOptions;
    /// <inheritdoc />
    public new GateioRestOptions ClientOptions => (GateioRestOptions)base.ClientOptions;
    
    internal DateTime? _lastExchangeInfoUpdate;
    #endregion
    
    #region Api clients
    /// <inheritdoc />
    public IGateioRestClientPerpetualFuturesApiExchangeData ExchangeData { get; }

    /// <inheritdoc />
    public IFuturesClient CommonFuturesClient => this;
    
    /// <inheritdoc />
    public string ExchangeName => "Gate.io";
    #endregion
    
    #region constructor/destructor
    internal GateioRestClientPerpetualFuturesApi(ILogger logger, HttpClient? httpClient, GateioRestOptions options)
        : base(logger, httpClient, options.Environment.RestAddress!, options, options.FutureOptions)
    {
        ExchangeData = new GateioRestClientPerpetualFuturesApiExchangeData(logger, this);

        requestBodyEmptyContent = "";
        requestBodyFormat = RequestBodyFormat.FormData;
        arraySerialization = ArrayParametersSerialization.MultipleValues;
    }
    #endregion

    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
    {
        throw new NotImplementedException();
    }

    public override TimeSyncInfo? GetTimeSyncInfo()
    {
        throw new NotImplementedException();
    }

    public override TimeSpan? GetTimeOffset()
    {
        throw new NotImplementedException();
    }

    public string GetSymbolName(string baseAsset, string quoteAsset)
    {
        throw new NotImplementedException();
    }

    async Task<WebCallResult<IEnumerable<Symbol>>> IBaseRestClient.GetSymbolsAsync(CancellationToken ct)
    {
        var contracts = await ExchangeData.GetFuturesContractsAsync(FuturesContractSettle.Usdt, ct: ct).ConfigureAwait(false);
        if (!contracts)
            return contracts.As<IEnumerable<Symbol>>(null);

        return contracts.As(contracts.Data.Select(s =>
            new Symbol()
            {
                SourceObject  = s,
                Name = s.Name,
                PriceDecimals = s.MarkPriceRound.Split('.')[1].Length,
                MinTradeQuantity = s.OrderSizeMin,
            }));
    }

    public Task<WebCallResult<Ticker>> GetTickerAsync(string symbol, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Ticker>>> GetTickersAsync(CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Kline>>> GetKlinesAsync(string symbol, TimeSpan timespan, DateTime? startTime = null, DateTime? endTime = null,
        int? limit = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<OrderBook>> GetOrderBookAsync(string symbol, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Trade>>> GetRecentTradesAsync(string symbol, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Balance>>> GetBalancesAsync(string? accountId = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<Order>> GetOrderAsync(string orderId, string? symbol = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<UserTrade>>> GetOrderTradesAsync(string orderId, string? symbol = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Order>>> GetOpenOrdersAsync(string? symbol = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Order>>> GetClosedOrdersAsync(string? symbol = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<OrderId>> CancelOrderAsync(string orderId, string? symbol = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }
    
    public event Action<OrderId>? OnOrderPlaced;
    public event Action<OrderId>? OnOrderCanceled;

    public Task<WebCallResult<OrderId>> PlaceOrderAsync(string symbol, CommonOrderSide side, CommonOrderType type, decimal quantity, decimal? price = null,
        int? leverage = null, string? accountId = null, string? clientOrderId = null,
        CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Position>>> GetPositionsAsync(CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }
    
    internal async Task<WebCallResult<T>> SendRequestInternal<T>(Uri uri, HttpMethod method, CancellationToken cancellationToken,
        Dictionary<string, object>? parameters = null, bool signed = false, HttpMethodParameterPosition? postPosition = null,
        ArrayParametersSerialization? arraySerialization = null, int weight = 1, bool ignoreRateLimit = false) where T : class
    {
        var result = await SendRequestAsync<T>(uri, method, cancellationToken, parameters, signed, postPosition, arraySerialization, weight, ignoreRatelimit: ignoreRateLimit).ConfigureAwait(false);
        return result;                    
    }

    public Uri GetUrl(string endpoint, string api, string settle, string version)
    {
        var result = BaseAddress;

        if (!string.IsNullOrEmpty(version))
            result = result.AppendPath($"v{version}");
        
        return new Uri(result.AppendPath(api).AppendPath(settle).AppendPath(endpoint));
    }
}