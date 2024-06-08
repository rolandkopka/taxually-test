using System.Text.Json;

namespace Taxually.TechnicalTest.Clients;

public class TaxuallyQueueClient: IQueueClient
{
    public Task EnqueueAsync<TPayload>(string queueName, TPayload payload)
    {
        // Code to send to message queue removed for brevity
        var payloadJson = JsonSerializer.Serialize(payload);
        Console.WriteLine($"Queue Client --- Queue: {queueName} Payload: {payloadJson}");
        return Task.CompletedTask;
    }
}