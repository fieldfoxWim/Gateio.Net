using CryptoExchange.Net.Objects;
using Gateio.Net.Enums;
using Gateio.Net.Objects.Models.Futures;

namespace Gateio.Net.Interfaces.Clients.PerpetualFutures;

public interface IGateioRestClientPerpetualFuturesApiExchangeData
{
    Task<WebCallResult<IEnumerable<GateioFutureContract>>> GetFuturesContractsAsync(FuturesContractSettle settle,
        CancellationToken ct = default);
}