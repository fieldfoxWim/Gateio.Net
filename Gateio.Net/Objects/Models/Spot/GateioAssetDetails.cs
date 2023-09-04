using Newtonsoft.Json;

namespace Gateio.Net.Objects.Models.Spot;

public class GateioAssetDetails
{
    /// <summary>
    /// Currency name
    /// </summary>
    public string Currency { get; set; }
    /// <summary>
    /// Whether currency is de-listed
    /// </summary>
    public bool Delisted { get; set; }
    /// <summary>
    /// Whether currency's withdrawal is disabled
    /// </summary>
    public bool withdraw_disabled { get; set; }
    /// <summary>
    /// Whether currency's withdrawal is delayed
    /// </summary>
    public bool withdraw_delayed{ get; set; }
    /// <summary>
    /// Whether currency's deposit is disabled
    /// </summary>
    public bool deposit_disabled{ get; set; }
    /// <summary>
    /// Whether currency's trading is disabled
    /// </summary>
    public bool trade_disabled { get; set; }
    /// <summary>
    /// Fixed fee rate. Only for fixed rate currencies, not valid for normal currencies
    /// </summary>
    [JsonProperty("fixed_rate")]
    public string? FixedRate { get; set; }
    /// <summary>
    /// Chain of currency
    /// </summary>
    public string chain { get; set; }
}