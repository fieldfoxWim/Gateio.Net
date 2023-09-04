using CryptoExchange.Net.Objects;

namespace Gateio.Net;

public class GateioEnvironment : TradeEnvironment
{
    /// <summary>
    /// Spot And Margin Rest API address
    /// </summary>
    public string SpotAndMarginRestAddress { get; }

    /// <summary>
    /// Spot And Margin Socket Streams address
    /// </summary>
    public string SpotAndMarginSocketAddress { get; }
    
    protected GateioEnvironment(
        string name, 
        string spotAndMarginRestAddress, 
        string spotAndMarginSocketAddress ) : base(name)
    {
        SpotAndMarginRestAddress = spotAndMarginRestAddress;
        SpotAndMarginSocketAddress = spotAndMarginSocketAddress;
    }
    
    /// <summary>
    /// Live environment
    /// </summary>
    public static GateioEnvironment Live { get; } 
        = new GateioEnvironment(TradeEnvironmentNames.Live, 
            GateioApiAddresses.Default.RestClientAddress,
            GateioApiAddresses.Default.SocketClientAddress
            );
    
    /// <summary>
    /// Testnet environment
    /// </summary>
    public static GateioEnvironment Testnet { get; }
        = new GateioEnvironment(TradeEnvironmentNames.Testnet,
            GateioApiAddresses.TestNet.RestClientAddress,
            GateioApiAddresses.TestNet.SocketClientAddress
            );
}