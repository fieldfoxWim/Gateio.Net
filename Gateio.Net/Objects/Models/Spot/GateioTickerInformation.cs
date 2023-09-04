using Newtonsoft.Json;

namespace Gateio.Net.Objects.Models.Spot;

public class GateioTickerInformation
{
    /// <summary>
    /// Gets or sets the currency pair.
    /// </summary>
    [JsonProperty("currency_pair")]
    public string CurrencyPair { get; set; }

    /// <summary>
    /// Gets or sets the last trading price.
    /// </summary>
    [JsonProperty("last")]
    public string Last { get; set; }

    /// <summary>
    /// Gets or sets the recent lowest ask.
    /// </summary>
    [JsonProperty("lowest_ask")]
    public string LowestAsk { get; set; }
    
    /// <summary>
    /// Gets or sets the recent highest bid.
    /// </summary>
    [JsonProperty("highest_bid")]
    public string HighestBid { get; set; }

    /// <summary>
    /// Gets or sets the change percentage in the last 24 hours.
    /// </summary>
    [JsonProperty("change_percentage")]
    public string ChangePercentage { get; set; }

    /// <summary>
    /// Gets or sets the utc0 timezone, the percentage change in the last 24 hours.
    /// </summary>
    [JsonProperty("change_utc0")]
    public string ChangeUtc0 { get; set; }

    /// <summary>
    /// Gets or sets the utc8 timezone, the percentage change in the last 24 hours.
    /// </summary>
    [JsonProperty("change_utc8")]
    public string ChangeUtc8 { get; set; }

    /// <summary>
    /// Gets or sets the base currency trade volume in the last 24 hours.
    /// </summary>
    [JsonProperty("base_volume")]
    public string BaseVolume { get; set; }

    /// <summary>
    /// Gets or sets the quote currency trade volume in the last 24 hours.
    /// </summary>
    [JsonProperty("quote_volume")]
    public string QuoteVolume { get; set; }

    /// <summary>
    /// Gets or sets the highest price in 24 hours.
    /// </summary>
    [JsonProperty("high_24h")]
    public string High24h { get; set; }

    /// <summary>
    /// Gets or sets the lowest price in 24 hours.
    /// </summary>
    [JsonProperty("low_24h")]
    public string Low24h { get; set; }

    /// <summary>
    /// Gets or sets the ETF net value.
    /// </summary>
    [JsonProperty("etf_net_value")]
    public string EtfNetValue { get; set; }

    /// <summary>
    /// Gets or sets the ETF previous net value at re-balancing time.
    /// </summary>
    [JsonProperty("etf_pre_net_value")]
    public string? EtfPreNetValue { get; set; }

    /// <summary>
    /// Gets or sets the ETF previous re-balancing time.
    /// </summary>
    [JsonProperty("etf_pre_timestamp")]
    public long? EtfPreTimestamp { get; set; }

    /// <summary>
    /// Gets or sets the ETF leverage.
    /// </summary>
    [JsonProperty("etf_leverage")]
    public string? EtfLeverage { get; set; }
}