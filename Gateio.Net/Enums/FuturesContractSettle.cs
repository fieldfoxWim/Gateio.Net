using CryptoExchange.Net.Attributes;

namespace Gateio.Net.Enums;

public enum FuturesContractSettle
{
    [Map("btc")]
    Btc = 1,
    [Map("usdt")]
    Usdt = 2,
    [Map("usd")]
    Usd = 3
}