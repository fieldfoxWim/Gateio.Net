using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;

namespace Gateio.Net.Objects.Options;

public class GateioRestOptions : RestExchangeOptions<GateioEnvironment>
{
    /// <summary>
    /// Default options for new clients
    /// </summary>
    public static GateioRestOptions Default { get; set; } = new GateioRestOptions()
    {
        Environment = GateioEnvironment.Live,
        AutoTimestamp = true
    };
    
    /// <summary>
    /// Spot API options
    /// </summary>
    public GateioRestApiOptions SpotAndMarginOptions { get; private set; } = new GateioRestApiOptions
    {
        RateLimiters = new List<IRateLimiter>
        {
            new RateLimiter()
                .AddPartialEndpointLimit("/", 200, TimeSpan.FromSeconds(10))
                //.AddPartialEndpointLimit("/sapi/", 180000, TimeSpan.FromMinutes(1))
                //.AddEndpointLimit("/api/v3/order", 50, TimeSpan.FromSeconds(10), HttpMethod.Post, true)
        }
    };
    
    /// <summary>
    /// Spot API options
    /// </summary>
    public GateioRestApiOptions FutureOptions { get; private set; } = new GateioRestApiOptions
    {
        RateLimiters = new List<IRateLimiter>
        {
            new RateLimiter()
                .AddPartialEndpointLimit("/", 200, TimeSpan.FromSeconds(10))
            //.AddPartialEndpointLimit("/sapi/", 180000, TimeSpan.FromMinutes(1))
            //.AddEndpointLimit("/api/v3/order", 50, TimeSpan.FromSeconds(10), HttpMethod.Post, true)
        }
    };
    
    internal GateioRestOptions Copy()
    {
        var options = Copy<GateioRestOptions>();
        options.SpotAndMarginOptions = SpotAndMarginOptions.Copy();
        return options;
    }
}