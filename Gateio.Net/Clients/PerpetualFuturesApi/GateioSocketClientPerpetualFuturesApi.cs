using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.Sockets;
using Gateio.Net.Interfaces.Clients.PerpetualFutures;
using Gateio.Net.Objects.@internal;
using Gateio.Net.Objects.Models.Spot;
using Gateio.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Gateio.Net.Clients.PerpetualFuturesApi;

public class GateioSocketClientPerpetualFuturesApi : SocketApiClient, IGateioSocketClientPerpetualFuturesApi
{
    #region fields
    /// <inheritdoc />
    public new GateioSocketOptions ClientOptions => (GateioSocketOptions)base.ClientOptions;
    /// <inheritdoc />
    public new GateioSocketApiOptions ApiOptions => (GateioSocketApiOptions)base.ApiOptions;
    
    internal DateTime? _lastExchangeInfoUpdate;
    #endregion
    
    public IGateioSocketClientPerpetualFuturesApiExchangeData ExchangeData { get; }
    
    #region constructor/destructor

    internal GateioSocketClientPerpetualFuturesApi(ILogger logger, GateioSocketOptions options) :
        base(logger, options.Environment.PerpetualFuturesSocketAddress, options, options.FutureOptions)
    {
        SetDataInterpreter((data) => string.Empty, null);
        
        ExchangeData = new GateioSocketClientPerpetualFuturesApiExchangeData(logger, this);
    }
    #endregion
    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
    {
        throw new NotImplementedException();
    }
    
    internal Task<CallResult<UpdateSubscription>> SubscribeAsync<T>(string url, string channel, IEnumerable<string> payload, Action<DataEvent<T>> onData, CancellationToken ct)
    {
        var now = DateTimeOffset.UtcNow;
        var unixTimestamp = now.ToUnixTimeSeconds();
        
        var request = new GateioSocketRequest
        {
            Id = ExchangeHelpers.NextId(),
            Time = unixTimestamp, 
            Channel = channel,
            Event = "subscribe",
            Payload = payload.ToArray(),
        };
        
        return SubscribeAsync(url, request, null, false, onData, ct);
        
    }

    protected override bool HandleQueryResponse<T>(SocketConnection socketConnection, object request, JToken data, out CallResult<T>? callResult)
    {
        throw new NotImplementedException();
    }

    protected override bool HandleSubscriptionResponse(SocketConnection socketConnection, SocketSubscription subscription, object request,
        JToken data, out CallResult<object>? callResult)
    {
        callResult = null!;
        if (data.Type != JTokenType.Object)
            return false;
        var response = data.ToObject<GateioSocketResponse<GateioTickerSubscriptionResponse>>();

        var id = response?.Id;
        if (id == null)
            return false;
        
        var bRequest = (GateioSocketRequest)request;
        if (bRequest.Id != id)
            return false;
        
        var errorOccured = response!.Error != null;
        if (errorOccured)
        {
            var error = response.Error;
            
            callResult = error != null ? new CallResult<object>(new ServerError( (int)error.Code, error.Message)) :
                new CallResult<object>(new ServerError("Unknown error"));
            return true;
        }

        _logger.Log(LogLevel.Trace, $"Socket {socketConnection.SocketId} Subscription completed");
        callResult = new CallResult<object>(response.Result ?? new object());
        return true;
    }

    protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, object request)
    {
        if (message.Type != JTokenType.Object)
            return false;

        var bRequest = (GateioSocketRequest)request;
        var channel = message["channel"];
        return channel != null && bRequest.Channel.Equals(channel.Value<string>());
    }

    protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, string identifier)
    {
        throw new NotImplementedException();
    }

    protected override Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection socketConnection)
    {
        throw new NotImplementedException();
    }

    protected override async Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscriptionToUnsub)
    {
        var topics = ((GateioSocketRequest)subscriptionToUnsub.Request!).Payload;
        var topicsToUnsub = new List<string>();
        foreach(var topic in topics)
        {
            if (connection.Subscriptions.Where(s => s != subscriptionToUnsub).Any(s => ((GateioSocketRequest?)s.Request)?.Payload.Contains(topic) == true))
                continue;

            topicsToUnsub.Add(topic);
        }

        if (!topicsToUnsub.Any())
        {
            _logger.LogInformation("No topics need unsubscribing (still active on other subscriptions)");
            return true;
        }
        var now = DateTimeOffset.UtcNow;
        var unixTimestamp = now.ToUnixTimeSeconds();
        var unsub = new GateioSocketRequest { Time = unixTimestamp, Channel = "unsubscribe", Payload = topicsToUnsub.ToArray(), Id = ExchangeHelpers.NextId() };
        var result = false;

        if (!connection.Connected)
            return true;

        await connection.SendAndWaitAsync(unsub, ClientOptions.RequestTimeout, null, 1, data =>
        {
            if (data.Type != JTokenType.Object)
                return false;

            var id = data["id"];
            if (id == null)
                return false;

            if ((int)id != unsub.Id)
                return false;

            var result = data["result"];
            if (result?.Type == JTokenType.Null)
            {
                result = true;
                return true;
            }

            return true;
        }).ConfigureAwait(false);
        return result;
    }
}