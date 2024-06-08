using System.Text.Json;

namespace Taxually.TechnicalTest.Clients;

public class TaxuallyHttpClient: IHttpClient
{
    public Task PostAsync<TRequest>(string url, TRequest request)
    {
        // Actual HTTP call removed for purposes of this exercise
        var requestJson = JsonSerializer.Serialize(request);
        Console.WriteLine($"Http Client --- Url: {url} Request: {requestJson}");
        return Task.CompletedTask;
    }
}