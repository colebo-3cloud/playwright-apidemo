namespace PlaywrightAPITests;

using System.Text.Json;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using PlaywrightAPITests.Models;

[TestClass]
public class PostAPITests : ApiBaseTest
{
    [TestInitialize]
    public async Task SetupTest()
    {
        await base.CreateAPIRequestContext("https://api.restful-api.dev/");
    }

    [TestMethod]
    public async Task ObjectPostTest()
    {
        var comp = new ObjectCreate
        {
            name = "Test Computer",
            data = new ObjectCreate.Data
            {
                year = 1999,
                price = 2500.00,
                CPU_Model = "Intel Core 2 Duo",
                Hard_Disk_Size = "2 TB"
            }
        };
        
        var postResponse = await Request.PostAsync("objects", new() { DataObject = comp });
        Assert.AreEqual(200, postResponse.Status, $"Expected status [200] and actual status [{postResponse.Status}]");
        var responseJson = await postResponse?.JsonAsync();
        var addedObject = responseJson?.Deserialize<ObjectResponse>();
        Assert.AreEqual("Intel Core 2 Duo", addedObject.data.CPU_Model, $"Expected CPU Model [{comp.data.CPU_Model}] and got Actual CPU Model [{addedObject.data.CPU_Model}]");
    }
}