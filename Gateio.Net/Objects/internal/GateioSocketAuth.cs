using Newtonsoft.Json;

namespace Gateio.Net.Objects.@internal;

public class GateioSocketAuth
{
    /// <summary>
    /// Authentication method. Currently only one method 'api_key' is accepted
    /// </summary>
    [JsonProperty("method")]
    public string Method { get; private set; } = "api_key";

    /// <summary>
    /// Authentication method. Currently only one method 'api_key' is accepted
    /// </summary>
    [JsonProperty("KEY")]
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Authentication method. Currently only one method 'api_key' is accepted
    /// </summary>
    [JsonProperty("SIGN")]
    public string Sign { get; set; } = string.Empty;
}