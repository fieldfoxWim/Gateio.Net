using CryptoExchange.Net.Objects.Options;

namespace Gateio.Net.Objects.Options;

public class GateioRestApiOptions : RestApiOptions
{
    internal GateioRestApiOptions Copy()
    {
        var result = base.Copy<GateioRestApiOptions>();
        return result;
    }
}