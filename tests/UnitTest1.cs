using Xunit;

namespace tests;

public class PaymentTests
{
    [Fact]
    public async Task GET_payment()
    {
        await using var application = new WebApplicationFactory<Api.Startup>();
        using var client = application.CreateClient();

        var response = await client.GetAsync("/api/payment");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact]
    public async Task POST_payment()
    {
        await using var application = new WebApplicationFactory<Api.Startup>();
        using var client = application.CreateClient();

        // Post payment 
        var postPaymentResponse = await client.SendAsync("/api/payment");
        // {
        //     "name":"Jeremy",
        //     "Card": "4242424242424242",
        //     "cvc": "123",
        //     "expiry": "2022-11-16"
        // }

        // Check payment status
        var singlePaymentResponse = await client.GetAsync("/api/payment" + postPaymentResponse.body.id);
        postPaymentResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        // Check payment data
    }
}