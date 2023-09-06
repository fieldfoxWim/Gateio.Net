using Newtonsoft.Json;

namespace Gateio.Net.Objects.Models.Spot;

public class GateioTick
{
    /// <summary>
    /// Gets or sets the currency pair.
    /// </summary>
    [JsonProperty("currency_pair")]
    public string CurrencyPair { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last price.
    /// </summary>
    [JsonProperty("last")]
    public string Last { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the recent best ask price.
    /// </summary>
    [JsonProperty("lowest_ask")]
    public string LowestAsk { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the recent best bid price.
    /// </summary>
    [JsonProperty("highest_bid")]
    public string HighestBid { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the change percentage.
    /// </summary>
    [JsonProperty("change_percentage")]
    public string ChangePercentage { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the base volume.
    /// </summary>
    [JsonProperty("base_volume")]
    public string BaseVolume { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quote volume.
    /// </summary>
    [JsonProperty("quote_volume")]
    public string QuoteVolume { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the highest price in 24 hours.
    /// </summary>
    [JsonProperty("high_24h")]
    public string High24h { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the lowest price in 24 hours.
    /// </summary>
    [JsonProperty("low_24h")]
    public string Low24h { get; set; } = string.Empty;
}