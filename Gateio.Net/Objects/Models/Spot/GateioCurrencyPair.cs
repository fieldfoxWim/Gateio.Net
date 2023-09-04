using Gateio.Net.Enums;
using Newtonsoft.Json;

namespace Gateio.Net.Objects.Models.Spot;

public class GateioCurrencyPair
{
    /// <summary>
    /// Currency pair
    /// </summary>
    public string Id { get; set; } = string.Empty;
    /// <summary>
    /// Base currency
    /// </summary>
    public string Base { get; set; } = string.Empty;
    /// <summary>
    /// Quote currency
    /// </summary>
    public string Quote { get; set; } = string.Empty;
    /// <summary>
    /// Trading fee
    /// </summary>
    public string Fee { get; set; } = string.Empty;
    /// <summary>
    /// Minimum amount of base currency to trade, null means no limit
    /// </summary>
    [JsonProperty("min_base_amount")]
    public string? MinBaseAmount { get; set; }
    /// <summary>
    /// Minimum amount of quote currency to trade, null means no limit
    /// </summary>
    [JsonProperty("min_quote_amount")]
    public string? MinQuoteAmount { get; set; }
    /// <summary>
    /// Amount scale
    /// </summary>
    [JsonProperty("amount_precision")]
    public int AmountPrecision { get; set; }
    /// <summary>
    /// Price scale
    /// </summary>
    public int Precision { get; set; }
    /// <summary>
    ///  How currency pair can be traded
    /// </summary>
    [JsonProperty("trade_status")]
    public GateioTradeStatus TradeStatus { get; set; }
    /// <summary>
    /// Sell start unix timestamp in seconds
    /// </summary>
    [JsonProperty("sell_start")]
    public decimal SellStart { get; set; }
    /// <summary>
    /// Buy start unix timestamp in seconds
    /// </summary>
    [JsonProperty("buy_start")]
    public decimal BuyStart { get; set; }
}