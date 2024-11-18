namespace PlaywrightAPITests;

using System.Text.Json;
using System.Text;
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
        var emplyee = new ObjectCreate
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
        
        var postResponse = await Request.PostAsync("objects/", new() { DataObject = emplyee });
        Assert.AreEqual(200, postResponse.Status, $"Expected status [200] and actual status [{postResponse.Status}]");
    }
}