namespace PlaywrightAPITests;

using System.Text.Json;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using PlaywrightAPITests.Models;

[TestClass]
public class WeatherAPITests : ApiBaseTest
{
    [TestInitialize]
    public async Task SetupTest()
    {
        await base.CreateAPIRequestContext("https://api.open-meteo.com/v1/");
    }

    [TestMethod]
    public async Task GetLocalCloudCover()
    {
        string requestString = CreateRequestString("-93.26", "44.97");
        var response = await Request.GetAsync(requestString);
        var responseJson = await response.JsonAsync();
        //Console.WriteLine(responseJson.ToString());
        var weatherData = responseJson?.Deserialize<WeatherApiResponseObject>();
        Console.WriteLine("Minneapolis Elevation: " + weatherData?.elevation);
        double? temp = weatherData?.GetTempForDate(DateTime.Now);
        Console.WriteLine("Today's Temp: " + temp + weatherData?.daily_units?.temperature_2m_max);

        Assert.AreEqual(200, response.Status, $"Expected status [200] and actual status [{response.Status}]");
        Assert.AreEqual(263, weatherData?.elevation, $"Expected elevation [263] and actual elevation [{weatherData?.elevation}]");
        Assert.IsNotNull(temp);
    }

    private string CreateRequestString(string lon, string lat)
    {
        return $"forecast?latitude={lat}&longitude={lon}&daily=temperature_2m_max&temperature_unit=fahrenheit&timezone=CST";
    }

    
}