using Gateio.Net.Enums;
using Newtonsoft.Json;

namespace Gateio.Net.Objects.@internal;

public class GateioSocketError
{
    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    [JsonProperty("code")]
    public GateioSocketErrorCode Code { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; } = string.Empty;
}