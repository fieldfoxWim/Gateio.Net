using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using Gateio.Net.Clients.SpotAndMarginApi;
using Gateio.Net.Interfaces.Clients;
using Gateio.Net.Interfaces.Clients.SpotAndMarginApi;
using Gateio.Net.Objects.Options;
using Microsoft.Extensions.Logging;

namespace Gateio.Net.Clients;

/// <inheritdoc cref="IGateioRestClient" />
public class GateioRestClient : BaseRestClient, IGateioRestClient
{
    #region Api clients

    /// <inheritdoc />
    public IGateioRestClientSpotAndMarginApi SpotAndMarginApi { get; }
    #endregion
    
    #region constructor/destructor

    /// <summary>
    /// Create a new instance of the GateioRestClient using provided options
    /// </summary>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    public GateioRestClient(Action<GateioRestOptions> optionsDelegate) : this(null, null, optionsDelegate)
    {
    }

    /// <summary>
    /// Create a new instance of the GateioRestClient using provided options
    /// </summary>
    public GateioRestClient(ILoggerFactory? loggerFactory = null, HttpClient? httpClient = null) : this(httpClient, loggerFactory, null)
    {
    }

    /// <summary>
    /// Create a new instance of the GateioRestClient using provided options
    /// </summary>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    /// <param name="loggerFactory">The logger factory</param>
    /// <param name="httpClient">Http client for this client</param>
    public GateioRestClient(HttpClient? httpClient, ILoggerFactory? loggerFactory, Action<GateioRestOptions>? optionsDelegate = null) : base(loggerFactory, "Gate.io")
    {
        var options = GateioRestOptions.Default.Copy();
        if (optionsDelegate != null)
            optionsDelegate(options);
        Initialize(options);

        SpotAndMarginApi = AddApiClient(new GateioRestClientSpotAndMarginApi(_logger, httpClient, options));
       }

    #endregion
    
    /// <summary>
    /// Set the default options to be used when creating new clients
    /// </summary>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    public static void SetDefaultOptions(Action<GateioRestOptions> optionsDelegate)
    {
        var options = GateioRestOptions.Default.Copy();
        optionsDelegate(options);
        GateioRestOptions.Default = options;
    }
    
    /// <inheritdoc />
    public void SetApiCredentials(ApiCredentials credentials)
    {
        SpotAndMarginApi.SetApiCredentials(credentials);
        
    }
}