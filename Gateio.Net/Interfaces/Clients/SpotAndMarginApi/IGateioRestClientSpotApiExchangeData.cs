using CryptoExchange.Net.Objects;
using Gateio.Net.Enums;
using Gateio.Net.Objects.Models.Spot;

namespace Gateio.Net.Interfaces.Clients.SpotAndMarginApi;

public interface IGateioRestClientSpotApiExchangeData
{
    Task<WebCallResult<IEnumerable<GateioCurrencyPair>>> GetCurrencyPairsAsync(CancellationToken ct= default);
    Task<WebCallResult<IEnumerable<GateioTickerInformation>>> GetTickerInformation(GateioTimezone timezone, CancellationToken ct= default);
    Task<WebCallResult<GateioTickerInformation>> GetTickerInformation(string currencyPair, GateioTimezone timezone, CancellationToken ct= default);
}