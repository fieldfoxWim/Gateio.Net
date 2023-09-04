using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using Gateio.Net.Enums;
using Gateio.Net.Interfaces.Clients.SpotAndMarginApi;
using Gateio.Net.Objects.Options;
using Microsoft.Extensions.Logging;

namespace Gateio.Net.Clients.SpotAndMarginApi;

/// <inheritdoc cref="IGateioSpotAndMarginApi" />
public class GateioRestClientSpotAndMarginApi : RestApiClient, IGateioRestClientSpotAndMarginApi, ISpotClient
{
    #region fields 
    /// <inheritdoc />
    public new GateioRestApiOptions ApiOptions => (GateioRestApiOptions)base.ApiOptions;
    /// <inheritdoc />
    public new GateioRestOptions ClientOptions => (GateioRestOptions)base.ClientOptions;
    #endregion
    
    #region Api clients
    /// <inheritdoc />
    public IGateioRestClientSpotApiExchangeData ExchangeData { get; }
    
    /// <inheritdoc />
    public ISpotClient CommonSpotClient => this;
    
    public string ExchangeName => "Gate.io";
    #endregion
    
    public GateioRestClientSpotAndMarginApi(ILogger logger, HttpClient? httpClient, GateioRestOptions options) 
        : base(logger, httpClient, options.Environment.SpotAndMarginRestAddress, options, options.SpotAndMarginOptions)
    {
        ExchangeData = new GateioRestClientSpotApiExchangeData(logger, this);
    }
    
    internal Uri GetUrl(string endpoint, string api, string? version = null)
    {
        var result = BaseAddress;

        if (!string.IsNullOrEmpty(version))
            result = result.AppendPath($"v{version}");
        
        return new Uri(result.AppendPath(api).AppendPath(endpoint));
    }

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
        return $"{baseAsset}_{quoteAsset}".ToUpper();
    }

    async Task<WebCallResult<IEnumerable<Symbol>>> IBaseRestClient.GetSymbolsAsync(CancellationToken ct)
    {
        var currencyPairs = await ExchangeData.GetCurrencyPairsAsync(ct: ct).ConfigureAwait(false);
        if (!currencyPairs)
            return currencyPairs.As<IEnumerable<Symbol>>(null);

        return currencyPairs.As(currencyPairs.Data.Select(s =>
            new Symbol()
            {
                SourceObject = s,
                Name = s.Id,
                PriceDecimals = s.Precision,
                QuantityDecimals = s.AmountPrecision,
                MinTradeQuantity = Convert.ToDecimal(s.MinBaseAmount)
            }));
    }

    public Task<WebCallResult<Symbol>> GetSymbolsAsync(string currency, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    async Task<WebCallResult<Ticker>> IBaseRestClient.GetTickerAsync(string symbol, CancellationToken ct = new CancellationToken())
    {
        if (string.IsNullOrWhiteSpace(symbol))
            throw new ArgumentException(nameof(symbol) + " required for Gate.io " + nameof(ISpotClient.GetTickerAsync), nameof(symbol));
        
        var ticker = await ExchangeData.GetTickerInformation(symbol, GateioTimezone.All, ct: ct).ConfigureAwait(false);
        if (!ticker)
            return ticker.As<Ticker>(null);

        return ticker.As(new Ticker()
        {
            SourceObject = ticker.Data,
            Symbol = ticker.Data.CurrencyPair,
            Volume = Convert.ToInt16(ticker.Data.BaseVolume),
            HighPrice = Convert.ToInt16(ticker.Data.HighestBid),
            LastPrice = Convert.ToInt16(ticker.Data.Last),
            LowPrice = Convert.ToInt16(ticker.Data.LowestAsk),
            Price24H = Convert.ToInt16(ticker.Data.High24h),
        });
    }

    async Task<WebCallResult<IEnumerable<Ticker>>> IBaseRestClient.GetTickersAsync(CancellationToken ct)
    {
        var tickerInformation = await ExchangeData.GetTickerInformation(GateioTimezone.All, ct);
        if (!tickerInformation)
            return tickerInformation.As<IEnumerable<Ticker>>(null);

        return tickerInformation.As(tickerInformation.Data.Select(t =>
            new Ticker()
            {
                SourceObject = t,
                Symbol = t.CurrencyPair,
                Volume = Convert.ToInt16(t.BaseVolume),
                HighPrice = Convert.ToInt16(t.HighestBid),
                LastPrice = Convert.ToInt16(t.Last),
                LowPrice = Convert.ToInt16(t.LowestAsk),
                Price24H = Convert.ToInt16(t.High24h),
            }));
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
        string? accountId = null, string? clientOrderId = null, CancellationToken ct = new CancellationToken())
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
}