using CryptoExchange.Net.Objects;
using Newtonsoft.Json;

namespace Gateio.Net.Objects.@internal;

public class GateioSocketResponse<T>
{
    /// <summary>
    /// Gets or sets the response time in seconds.
    /// </summary>
    [JsonProperty("time")]
    public int Time { get; set; }

    /// <summary>
    /// Gets or sets the request ID extracted from the client request payload if the client request has one.
    /// </summary>
    [JsonProperty("id")]
    public int? Id { get; set; }

    /// <summary>
    /// Gets or sets the WebSocket channel name.
    /// </summary>
    [JsonProperty("channel")]
    public string Channel { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the server-side channel event (i.e., update) or event used in requests initiated from the client.
    /// </summary>
    [JsonProperty("event")]
    public string Event { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the error details. Null if the server accepts the client request; otherwise, the detailed reason why the request is rejected.
    /// </summary>
    [JsonProperty("error")]
    public GateioSocketError? Error { get; set; }
    
    [JsonProperty("result")]
    public T? Result { get; set; }
}