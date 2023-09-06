namespace Gateio.Net;

public class GateioApiAddresses
{
    /// <summary>
    /// The address used by the GateioClient for the Spot API
    /// </summary>
    public string RestClientAddress { get; set; } = string.Empty;
    /// <summary>
    /// The address used by the GateioSocketClient for the Spot
    /// </summary>
    public string SocketClientSpotAddress { get; set; } = string.Empty;
    /// <summary>
    /// The address used by the GateioSocketClient for the futures
    /// </summary>
    public string SocketClientFuturesAddress { get; set; } = string.Empty;

    /// <summary>
    /// The default addresses to connect to the binance.com API
    /// </summary>
    public static GateioApiAddresses Default = new GateioApiAddresses
    {
        RestClientAddress = "https://api.gateio.ws/api/",
        SocketClientSpotAddress = "wss://api.gateio.ws/ws/",
        SocketClientFuturesAddress = "wss://fx-ws.gateio.ws/",
    };
    
    /// <summary>
    /// The addresses to connect to the binance testnet
    /// </summary>
    public static GateioApiAddresses TestNet = new GateioApiAddresses
    {
        RestClientAddress = "https://fx-api-testnet.gateio.ws/api",
        SocketClientSpotAddress = string.Empty,
        SocketClientFuturesAddress = "wss://fx-ws-testnet.gateio.ws/",
    };
    
}