using CryptoExchange.Net.Objects.Options;

namespace Gateio.Net.Objects.Options;

public class GateioSocketApiOptions : SocketApiOptions
{
    internal GateioSocketApiOptions Copy()
    {
        var result = Copy<GateioSocketApiOptions>();
        return result;
    }
}