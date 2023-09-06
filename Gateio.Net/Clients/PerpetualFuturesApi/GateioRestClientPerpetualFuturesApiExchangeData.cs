using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Gateio.Net.Enums;
using Gateio.Net.Interfaces.Clients.PerpetualFutures;
using Gateio.Net.Objects.Models.Futures;
using Microsoft.Extensions.Logging;

namespace Gateio.Net.Clients.PerpetualFuturesApi;

public class GateioRestClientPerpetualFuturesApiExchangeData : IGateioRestClientPerpetualFuturesApiExchangeData
{
    private const string futuresApi = "futures";
    private const string version = "4";

    private const string contracts = "contracts";
    
    private readonly ILogger _logger;
    private readonly GateioRestClientPerpetualFuturesApi _baseClient;
    
    internal GateioRestClientPerpetualFuturesApiExchangeData(ILogger logger, GateioRestClientPerpetualFuturesApi baseClient)
    {
        _logger = logger;
        _baseClient = baseClient;
    }

    public async Task<WebCallResult<IEnumerable<GateioFutureContract>>> GetFuturesContractsAsync(FuturesContractSettle settle, CancellationToken ct = default)
    {
        return await _baseClient
            .SendRequestInternal<IEnumerable<GateioFutureContract>>(_baseClient.GetUrl(contracts, futuresApi, EnumConverter.GetString(settle), version),
                HttpMethod.Get, ct).ConfigureAwait(false);
    }
}