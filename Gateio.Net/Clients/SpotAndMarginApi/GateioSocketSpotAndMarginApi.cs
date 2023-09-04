using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.Sockets;
using Gateio.Net.Interfaces.Clients.SpotAndMarginApi;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Gateio.Net.Clients.SpotAndMarginApi;

/// <inheritdoc />
public class GateioSocketSpotAndMarginApi : SocketApiClient, IGateioSocketClientSpotAndMarginApi
{
    
    public GateioSocketSpotAndMarginApi(ILogger logger, string baseAddress, SocketExchangeOptions options, SocketApiOptions apiOptions) : base(logger, baseAddress, options, apiOptions)
    {
    }

    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
    {
        throw new NotImplementedException();
    }

    protected override bool HandleQueryResponse<T>(SocketConnection socketConnection, object request, JToken data, out CallResult<T>? callResult)
    {
        throw new NotImplementedException();
    }

    protected override bool HandleSubscriptionResponse(SocketConnection socketConnection, SocketSubscription subscription, object request,
        JToken data, out CallResult<object>? callResult)
    {
        throw new NotImplementedException();
    }

    protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, object request)
    {
        throw new NotImplementedException();
    }

    protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, string identifier)
    {
        throw new NotImplementedException();
    }

    protected override Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection socketConnection)
    {
        throw new NotImplementedException();
    }

    protected override Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscriptionToUnsub)
    {
        throw new NotImplementedException();
    }
}