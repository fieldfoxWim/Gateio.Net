using CryptoExchange.Net.Objects;

namespace Gateio.Net;

public class GateioEnvironment : TradeEnvironment
{
    /// <summary>
    /// Spot And Margin Rest API address
    /// </summary>
    public string RestAddress { get; }

    /// <summary>
    /// Spot And Margin Socket Streams address
    /// </summary>
    public string SpotAndMarginSocketAddress { get; }
    
    /// <summary>
    /// Spot And Margin Socket Streams address
    /// </summary>
    public string PerpetualFuturesSocketAddress { get; }
    
    protected GateioEnvironment(
        string name, 
        string restAddress, 
        string spotAndMarginSocketAddress,
        string futuresSocketAddress) : base(name)
    {
        RestAddress = restAddress;
        SpotAndMarginSocketAddress = spotAndMarginSocketAddress;
        PerpetualFuturesSocketAddress = futuresSocketAddress;
    }
    
    /// <summary>
    /// Live environment
    /// </summary>
    public static GateioEnvironment Live { get; } 
        = new GateioEnvironment(TradeEnvironmentNames.Live, 
            GateioApiAddresses.Default.RestClientAddress,
            GateioApiAddresses.Default.SocketClientSpotAddress,
            GateioApiAddresses.Default.SocketClientFuturesAddress
            );
    
    /// <summary>
    /// Testnet environment
    /// </summary>
    public static GateioEnvironment Testnet { get; }
        = new GateioEnvironment(TradeEnvironmentNames.Testnet,
            GateioApiAddresses.TestNet.RestClientAddress,
            GateioApiAddresses.TestNet.SocketClientSpotAddress,
            GateioApiAddresses.TestNet.SocketClientFuturesAddress
            );
}