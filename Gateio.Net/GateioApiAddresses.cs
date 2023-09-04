namespace Gateio.Net;

public class GateioApiAddresses
{
    /// <summary>
    /// The address used by the GateioClient for the Spot API
    /// </summary>
    public string RestClientAddress { get; set; } = string.Empty;
    /// <summary>
    /// The address used by the GateioSocketClient for the Spot streams
    /// </summary>
    public string SocketClientAddress { get; set; } = string.Empty;
    
    /// <summary>
    /// The default addresses to connect to the binance.com API
    /// </summary>
    public static GateioApiAddresses Default = new GateioApiAddresses
    {
        RestClientAddress = "https://api.gateio.ws/api/",
        SocketClientAddress = "wss://api.gateio.ws/ws/",
    };
    
    /// <summary>
    /// The addresses to connect to the binance testnet
    /// </summary>
    public static GateioApiAddresses TestNet = new GateioApiAddresses
    {
        RestClientAddress = "https://fx-api-testnet.gateio.ws/api",
        SocketClientAddress = string.Empty,
    };
    
}