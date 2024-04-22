using System.Net;
using System.Text.RegularExpressions;
using Gateio.Net.Clients;
using Gateio.Net.Interfaces.Clients;
using Gateio.Net.Objects.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Gateio.Net;

public static class GateioHelpers
{
    /// <summary>
        /// Add the IGateioClient and IGateioSocketClient to the sevice collection so they can be injected
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="defaultRestOptionsDelegate">Set default options for the rest client</param>
        /// <param name="defaultSocketOptionsDelegate">Set default options for the socket client</param>
        /// <param name="socketClientLifeTime">The lifetime of the IBinanceSocketClient for the service collection. Defaults to Singleton.</param>
        /// <returns></returns>
        public static IServiceCollection AddGateio(
            this IServiceCollection services,
            Action<GateioRestOptions>? defaultRestOptionsDelegate = null,
            Action<GateioSocketOptions>? defaultSocketOptionsDelegate = null,
            ServiceLifetime? socketClientLifeTime = null)
        {
            var restOptions = GateioRestOptions.Default.Copy();

            if (defaultRestOptionsDelegate != null)
            {
                defaultRestOptionsDelegate(restOptions);
                GateioRestClient.SetDefaultOptions(defaultRestOptionsDelegate);
            }

            if (defaultSocketOptionsDelegate != null)
                GateioSocketClient.SetDefaultOptions(defaultSocketOptionsDelegate);

            services.AddHttpClient<IGateioRestClient, GateioRestClient>(options =>
            {
                options.Timeout = restOptions.RequestTimeout;
            }).ConfigurePrimaryHttpMessageHandler(() => {
                var handler = new HttpClientHandler();
                if (restOptions.Proxy != null)
                {
                    handler.Proxy = new WebProxy
                    {
                        Address = new Uri($"{restOptions.Proxy.Host}:{restOptions.Proxy.Port}"),
                        Credentials = restOptions.Proxy.Password == null ? null : new NetworkCredential(restOptions.Proxy.Login, restOptions.Proxy.Password)
                    };
                }
                return handler;
            });
            
            services.AddTransient<IGateioRestClient, GateioRestClient>();
            if (socketClientLifeTime == null)
                services.AddSingleton<IGateioSocketClient, GateioSocketClient>();
            else
                services.Add(new ServiceDescriptor(typeof(IGateioSocketClient), typeof(GateioSocketClient), socketClientLifeTime.Value));
            return services;
        }
    
    /// <summary>
    /// Validate the string is a valid Gate.io symbol.
    /// </summary>
    /// <param name="symbolString">string to validate</param> 
    public static void ValidateGateioSymbol(this string symbolString)
    {
        if (string.IsNullOrEmpty(symbolString))
            throw new ArgumentException("Symbol is not provided");

        if(!Regex.IsMatch(symbolString, "^[a-zA-Z0-9]{1,}_[a-zA-Z0-9]{3,5}$"))
            throw new ArgumentException($"{symbolString} is not a valid Gate.io symbol. Should be [BaseAsset]_[QuoteAsset], e.g. BTC_USDT");
    }
}