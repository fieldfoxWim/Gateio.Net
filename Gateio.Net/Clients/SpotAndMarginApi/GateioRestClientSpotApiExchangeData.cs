using CryptoExchange.Net.Objects;
using Gateio.Net.Enums;
using Gateio.Net.Interfaces.Clients.SpotAndMarginApi;
using Gateio.Net.Objects.Models.Spot;
using Microsoft.Extensions.Logging;

namespace Gateio.Net.Clients.SpotAndMarginApi;

public class GateioRestClientSpotApiExchangeData : IGateioRestClientSpotApiExchangeData
{
    private const string spotApi = "spot";
    private const string marginApi = "margin";
    private const string version = "4";

    // SPOT
    private const string allCurrencies = "currencies";
    private const string currencyDetails = "currencies/{0}";
    private const string supportedCurrencies = "currency_pairs";
    private const string supportedCurrencyDetails = "currency_pairs/{0}";
    private const string tickers = "tickers";
    private const string orderBook = "order_book";
    private const string trades = "trades";
    private const string candlesticks = "candlesticks";
    private const string tradingFeeRate = "fee";
    private const string batchUserTadingFeeRates = "batch_fee";
    private const string spotAccounts = "accounts";
    private const string accountBook = "account_book";

    // MARGIN
    private const string crossMarginCurrencies = "cross/currencies";
    private const string crossMarginCurrencyDetail = "cross/currencies";
    private readonly GateioRestClientSpotAndMarginApi _baseClient;


    private readonly ILogger _logger;

    internal GateioRestClientSpotApiExchangeData(ILogger logger, GateioRestClientSpotAndMarginApi baseClient)
    {
        _logger = logger;
        _baseClient = baseClient;
    }

    #region Currency pairs

    public async Task<WebCallResult<IEnumerable<GateioCurrencyPair>>> GetCurrencyPairsAsync(
        CancellationToken ct = default)
    {
        return await _baseClient.SendRequestInternal<IEnumerable<GateioCurrencyPair>>(
            _baseClient.GetUrl(supportedCurrencies, spotApi, version),
            HttpMethod.Get, ct).ConfigureAwait(false);
    }

    #endregion

    #region Tickerinformation

    public async Task<WebCallResult<IEnumerable<GateioTickerInformation>>> GetTickerInformation(GateioTimezone timezone, CancellationToken ct = default)
    {
        return await _baseClient
            .SendRequestInternal<IEnumerable<GateioTickerInformation>>(_baseClient.GetUrl(tickers, spotApi, version),
                HttpMethod.Get, ct).ConfigureAwait(false);
    }
    
    public async Task<WebCallResult<GateioTickerInformation>> GetTickerInformation(string symbol, GateioTimezone timezone, CancellationToken ct = default)
    {
        symbol.ValidateGateioSymbol();
        var parameters = new Dictionary<string, object>
        {
            { "currency_pair", symbol },
            { "timezone", timezone }
        };
        
        return await _baseClient
            .SendRequestInternal<GateioTickerInformation>(_baseClient.GetUrl(tickers, spotApi, version),
                HttpMethod.Get, ct, parameters, false, HttpMethodParameterPosition.InUri).ConfigureAwait(false);
    }

    #endregion

    #region asset details

    public async Task<WebCallResult<List<GateioAssetDetails>>> GetAssetDetailsAsync(CancellationToken ct = default)
    {
        return await _baseClient
            .SendRequestInternal<List<GateioAssetDetails>>(_baseClient.GetUrl(allCurrencies, spotApi, version),
                HttpMethod.Get, ct).ConfigureAwait(false);
    }

    #endregion

    #region asset detail

    public async Task<WebCallResult<GateioAssetDetails>> GetAssetDetailAsync(string currency,
        CancellationToken ct = default)
    {
        return await _baseClient
            .SendRequestInternal<GateioAssetDetails>(
                _baseClient.GetUrl(string.Format(currencyDetails, currency), spotApi, version), HttpMethod.Get, ct)
            .ConfigureAwait(false);
    }

    #endregion
}