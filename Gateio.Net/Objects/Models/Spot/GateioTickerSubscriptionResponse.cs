using Gateio.Net.Objects.@internal;
using Newtonsoft.Json;

namespace Gateio.Net.Objects.Models.Spot;


public class GateioTickerSubscriptionResponse
{
    /// <summary>
    /// Gets or sets status
    /// </summary>
    [JsonProperty("result")]
    public string status { get; set; }
}