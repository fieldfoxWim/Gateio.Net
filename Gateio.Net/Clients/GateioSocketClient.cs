using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using Gateio.Net.Clients.PerpetualFuturesApi;
using Gateio.Net.Clients.SpotAndMarginApi;
using Gateio.Net.Interfaces.Clients;
using Gateio.Net.Interfaces.Clients.PerpetualFutures;
using Gateio.Net.Interfaces.Clients.SpotAndMarginApi;
using Gateio.Net.Objects.Options;
using Microsoft.Extensions.Logging;

namespace Gateio.Net.Clients;

/// <inheritdoc cref="IGateioSocketClient" />
public class GateioSocketClient : BaseSocketClient, IGateioSocketClient
{
    #region Api clients

    /// <inheritdoc />
    public IGateioSocketClientSpotAndMarginApi SpotAndMarginApi { get; set; }
    
    public IGateioSocketClientPerpetualFuturesApi PerpetualFuturesApi { get; set; }
    
    #endregion
    
    #region constructor/destructor
    /// <summary>
    /// Create a new instance of BinanceSocketClient
    /// </summary>
    /// <param name="loggerFactory">The logger factory</param>
    public GateioSocketClient(ILoggerFactory? loggerFactory = null) : this((x) => { }, loggerFactory)
    {
    }

    /// <summary>
    /// Create a new instance of BinanceSocketClient
    /// </summary>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    public GateioSocketClient(Action<GateioSocketOptions> optionsDelegate) : this(optionsDelegate, null)
    {
    }

    /// <summary>
    /// Create a new instance of BinanceSocketClient
    /// </summary>
    /// <param name="loggerFactory">The logger factory</param>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    public GateioSocketClient(Action<GateioSocketOptions> optionsDelegate, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Gate.io")
    {
        var options = GateioSocketOptions.Default.Copy();
        optionsDelegate(options);
        Initialize(options);

        SpotAndMarginApi = AddApiClient(new GateioSocketSpotAndMarginApi(_logger, options));
        PerpetualFuturesApi = AddApiClient(new GateioSocketClientPerpetualFuturesApi(_logger, options));
    }
    #endregion
    
    /// <summary>
    /// Set the default options to be used when creating new clients
    /// </summary>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    public static void SetDefaultOptions(Action<GateioSocketOptions> optionsDelegate)
    {
        var options = GateioSocketOptions.Default.Copy();
        optionsDelegate(options);
        GateioSocketOptions.Default = options;
    }

    /// <inheritdoc />
    public void SetApiCredentials(ApiCredentials credentials)
    {
    }
}