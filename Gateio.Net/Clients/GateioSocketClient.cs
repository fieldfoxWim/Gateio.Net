using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using Gateio.Net.Interfaces.Clients;
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
    #endregion
    public GateioSocketClient(ILoggerFactory? logger, string name) : base(logger, name)
    {
    }
    
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