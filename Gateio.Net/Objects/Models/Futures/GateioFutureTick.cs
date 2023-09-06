using Newtonsoft.Json;

namespace Gateio.Net.Objects.Models.Futures;

public class GateioFutureTick
{
     /// <summary>
    /// Gets or sets the futures contract name.
    /// </summary>
    [JsonProperty("contract")]
    public string Contract { get; set; }

    /// <summary>
    /// Gets or sets the last price.
    /// </summary>
    [JsonProperty("last")]
    public string Last { get; set; }

    /// <summary>
    /// Gets or sets the change percentage.
    /// </summary>
    [JsonProperty("change_percentage")]
    public string ChangePercentage { get; set; }

    /// <summary>
    /// Gets or sets the funding rate.
    /// </summary>
    [JsonProperty("funding_rate")]
    public string FundingRate { get; set; }

    /// <summary>
    /// Gets or sets the indicative funding rate.
    /// </summary>
    [JsonProperty("funding_rate_indicative")]
    public string FundingRateIndicative { get; set; }

    /// <summary>
    /// Gets or sets the mark price.
    /// </summary>
    [JsonProperty("mark_price")]
    public string MarkPrice { get; set; }

    /// <summary>
    /// Gets or sets the index price.
    /// </summary>
    [JsonProperty("index_price")]
    public string IndexPrice { get; set; }

    /// <summary>
    /// Gets or sets the total size.
    /// </summary>
    [JsonProperty("total_size")]
    public string TotalSize { get; set; }

    /// <summary>
    /// Gets or sets the 24-hour trading volume.
    /// </summary>
    [JsonProperty("volume_24h")]
    public string Volume24h { get; set; }

    /// <summary>
    /// Gets or sets the quanto base rate.
    /// </summary>
    [JsonProperty("quanto_base_rate")]
    public string QuantoBaseRate { get; set; }

    /// <summary>
    /// Gets or sets the 24-hour trading volume in BTC.
    /// </summary>
    [JsonProperty("volume_24h_btc")]
    public string Volume24hBTC { get; set; }

    /// <summary>
    /// Gets or sets the 24-hour trading volume in USD.
    /// </summary>
    [JsonProperty("volume_24h_usd")]
    public string Volume24hUSD { get; set; }

    /// <summary>
    /// Gets or sets the 24-hour trading volume in the quote currency.
    /// </summary>
    [JsonProperty("volume_24h_quote")]
    public string Volume24hQuote { get; set; }

    /// <summary>
    /// Gets or sets the 24-hour trading volume in the settlement currency.
    /// </summary>
    [JsonProperty("volume_24h_settle")]
    public string Volume24hSettle { get; set; }

    /// <summary>
    /// Gets or sets the 24-hour trading volume in the base currency.
    /// </summary>
    [JsonProperty("volume_24h_base")]
    public string Volume24hBase { get; set; }

    /// <summary>
    /// Gets or sets the lowest price in the last 24 hours.
    /// </summary>
    [JsonProperty("low_24h")]
    public string Low24h { get; set; }

    /// <summary>
    /// Gets or sets the highest price in the last 24 hours.
    /// </summary>
    [JsonProperty("high_24h")]
    public string High24h { get; set; }
}