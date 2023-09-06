using CryptoExchange.Net.Sockets;
using Gateio.Net.Clients;
using Gateio.Net.Enums;
using Gateio.Net.Objects.@internal;
using Gateio.Net.Objects.Models.Futures;
using Gateio.Net.Objects.Models.Spot;
using NUnit.Framework;

namespace Gateio.Net.UnitTests;

[TestFixture]
public class IntegrationTest
{
    [Test]
    public async Task CurrenciesTest()
    {
        var client = new GateioRestClient(options => {  });
        var symbols = await client.SpotAndMarginApi.ExchangeData.GetCurrencyPairsAsync();
        Assert.IsNotEmpty(symbols.ToString());
    }
    
    // [TestCase("BTC")]
    // [TestCase("EUR")]
    // [TestCase("ETH")]
    // [TestCase("USD")]
    // public async Task CurrencyTest(string currency)
    // {
    //     var client = new GateioRestClient(options => {  });
    //     var symbol = await client.SpotAndMarginApi.ExchangeData.GetCurrencyPairsAsync((currency);
    //    
    //     Assert.IsNotNull(symbol);
    // }
    
    [Test]
    public async Task SymbolsTest()
    {
        var client = new GateioRestClient(options => {  });
        var symbols = await client.SpotAndMarginApi.CommonSpotClient.GetSymbolsAsync();
       
        Assert.IsNotNull(symbols);
    }
    
    [Test]
    public async Task TickerTest()
    {
        var client = new GateioSocketClient(options => {  });
        var symbols = await client.SpotAndMarginApi.ExchangeData.SubscribeToTickerUpdatesAsync("BTC_USDT", OnMessage);
        
        await Task.Delay(10000);

        Assert.IsNotNull(symbols);
    }

    private void OnMessage(DataEvent<GateioSocketResponse<GateioTick>> obj)
    {
        Assert.IsNotNull(obj.Data);
    }
    
    [Test]
    public async Task FutureSymbolsTest()
    {
        var client = new GateioRestClient(options => {  });
        var symbols = await client.PerpetualFuturesApi.ExchangeData.GetFuturesContractsAsync(FuturesContractSettle.Usdt);
       
        Assert.IsNotNull(symbols);
    }
    
    [Test]
    public async Task FuturesTickerTest()
    {
        var client = new GateioSocketClient(options => {  });
        var symbols = await client.PerpetualFuturesApi.ExchangeData.SubscribeToTickerUpdatesAsync(FuturesContractSettle.Usdt,"BTC_USDT", OnFuturesMessage);
        
        await Task.Delay(30000);

        Assert.IsNotNull(symbols);
    }

    private void OnFuturesMessage(DataEvent<GateioSocketResponse<List<GateioFutureTick>>> obj)
    {
        Assert.IsNotNull(obj.Data);
    }
}