using CryptoExchange.Net.Attributes;

namespace Gateio.Net.Enums;
/// <summary>
/// How currency pair can be traded
/// </summary>
public enum GateioTradeStatus
{
    /// <summary>
    /// Cannot be bought or sold
    /// </summary>
    [Map("untradable")]
    Untradable = 1,
    /// <summary>
    /// Can be bought
    /// </summary>
    [Map("buyable")]
    Buyable = 2,
    /// <summary>
    /// Can be sold
    /// </summary>
    [Map("sellable")]
    Sellable = 3,
    /// <summary>
    /// Can be bought or sold
    /// </summary>
    [Map("tradable")]
    Tradable = 4
}