using CryptoExchange.Net.Attributes;

namespace Gateio.Net.Enums;

public enum GateioTimezone
{
    [Map("utc0")]
    Utc0,
    [Map("utc8")]
    Utc8,
    [Map("all")]
    All
}