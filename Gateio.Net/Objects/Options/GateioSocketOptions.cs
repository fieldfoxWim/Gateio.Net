using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;

namespace Gateio.Net.Objects.Options;

public class GateioSocketOptions : SocketExchangeOptions<GateioEnvironment>
{
    /// <summary>
    /// Default options for new clients
    /// </summary>
    public static GateioSocketOptions Default { get; set; } = new GateioSocketOptions()
    {
        Environment = GateioEnvironment.Live,
        SocketSubscriptionsCombineTarget = 10
    };

    /// <summary>
    /// Options for the Spot API
    /// </summary>
    public GateioSocketApiOptions SpotOptions { get; private set; } = new GateioSocketApiOptions()
    {
        RateLimiters = new List<IRateLimiter>
        {
            new RateLimiter()
                .AddConnectionRateLimit("api.gateio.ws/ws", 5, TimeSpan.FromSeconds(1))
        }
    };
    
    internal GateioSocketOptions Copy()
    {
        var options = Copy<GateioSocketOptions>();
        options.SpotOptions = SpotOptions.Copy();
        return options;
    }
}