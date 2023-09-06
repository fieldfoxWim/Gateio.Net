using Newtonsoft.Json;

namespace Gateio.Net.Objects.Models.Spot;

public class GateioAssetDetails
{
    /// <summary>
    /// Currency name
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; } = String.Empty;
    /// <summary>
    /// Whether currency is de-listed
    /// </summary>
    [JsonProperty("delisted")]
    public bool Delisted { get; set; }
    /// <summary>
    /// Whether currency's withdrawal is disabled
    /// </summary>
    [JsonProperty("withdraw_disabled")]
    public bool WithdrawDisabled { get; set; }
    /// <summary>
    /// Whether currency's withdrawal is delayed
    /// </summary>
    [JsonProperty("withdraw_delayed")]
    public bool WithdrawDelayed{ get; set; }
    /// <summary>
    /// Whether currency's deposit is disabled
    /// </summary>
    [JsonProperty("deposit_disabled")]
    public bool DepositDisabled{ get; set; }
    /// <summary>
    /// Whether currency's trading is disabled
    /// </summary>
    [JsonProperty("trade_disabled")]
    public bool TradeDisabled { get; set; }
    /// <summary>
    /// Fixed fee rate. Only for fixed rate currencies, not valid for normal currencies
    /// </summary>
    [JsonProperty("fixed_rate")]
    public string? FixedRate { get; set; }
    /// <summary>
    /// Chain of currency
    /// </summary>
    [JsonProperty("chain")]
    public string Chain { get; set; } = String.Empty;
}