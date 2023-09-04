using Gateio.Net.Clients;
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
}