using Newtonsoft.Json;

namespace Gateio.Net.Objects.Models.Futures;

public class GateioFutureBookTick
{
    /// <summary>
    /// Gets or sets the book ticker generated timestamp in milliseconds.
    /// </summary>
    [JsonProperty("t")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Gets or sets the order book update ID.
    /// </summary>
    [JsonProperty("u")]
    public string OrderBookUpdateId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the contract name.
    /// </summary>
    [JsonProperty("s")]
    public string ContractName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the best bid price. If no bids, it's an empty string.
    /// </summary>
    [JsonProperty("b")]
    public string BestBidPrice { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the best bid size. If no bids, it will be 0.
    /// </summary>
    [JsonProperty("B")]
    public decimal BestBidSize { get; set; }

    /// <summary>
    /// Gets or sets the best ask price. If no asks, it's an empty string.
    /// </summary>
    [JsonProperty("a")]
    public string BestAskPrice { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the best ask size. If no asks, it will be 0.
    /// </summary>
    [JsonProperty("A")]
    public decimal BestAskSize { get; set; }
}