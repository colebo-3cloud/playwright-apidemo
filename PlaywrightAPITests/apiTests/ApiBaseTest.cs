namespace PlaywrightAPITests;

using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

[TestClass]
public class ApiBaseTest : PlaywrightTest
{

    protected IAPIRequestContext Request = null!;


    public async Task CreateAPIRequestContext(string baseURL)
    {
        var headers = new Dictionary<string, string>();
        // Add token if needed here
        //headers.Add("Authorization", "token");
        headers.Add("content-type", "application/json");

        Request = await Playwright.APIRequest.NewContextAsync(new() {
            BaseURL = baseURL,
            ExtraHTTPHeaders = headers
        });
    }

    [TestCleanup]
    public async Task TearDown()
    {
        await Request.DisposeAsync();
    }
}