using Newtonsoft.Json;

namespace Gateio.Net.Objects.@internal;

public class GateioSocketRequest
{
    /// <summary>
    /// Optional request id which will be sent back by the server to help you identify which request the server responds to
    /// </summary>
    [JsonProperty("id")]
    public int? Id { get; set; }
    
    /// <summary>
    /// Request time in seconds. Gap between request time and server time must not exceed 60 seconds
    /// </summary>
    [JsonProperty("time")]
    public long Time { get; set; }

    /// <summary>
    /// Authentication credentials for private channels
    /// </summary>
    [JsonProperty("auth")]
    public GateioSocketAuth? Auth { get; set; }
    /// <summary>
    /// WebSocket channel to subscribe to.
    /// </summary>
    [JsonProperty("channel")]
    public string Channel { get; set; } = string.Empty;
    /// <summary>
    /// Channel operation event, i.e.subscribe, unsubscribe
    /// </summary>
    [JsonProperty("event")]
    public string Event { get; set; } = string.Empty;
    /// <summary>
    /// Optional request detail parameters
    /// </summary>
    [JsonProperty("payload")] 
    public string[] Payload { get; set; } = default!;
}