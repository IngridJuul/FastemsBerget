using System.Net.Http;
using System.Text.Json;
using FastemsBerget.Models;
using RamBase.Api.Sdk;
using RamBase.Api.Sdk.Authentication;
using RamBase.Api.Sdk.Request;
using RamBaseApiSdk.Authentication;

namespace FastemsBerget.Services
{
    public interface IWorkOrderService
    {
        Task<int> HandleWorkOrderStartedAsync(WorkOrderWebhook webhookData, string accessToken);
    }

    public class WorkOrderService : IWorkOrderService
    {
        private readonly HttpClient _httpClient;

        public WorkOrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> HandleWorkOrderStartedAsync(WorkOrderWebhook webhookData, string accessToken)
        {


            System.Console.WriteLine("Service lag data: " + webhookData.ProductionWorkOrderId);
            // Perform a follow-up API call to get precise data
            var apiUrl = $"https://api.rambase.net/production/work-orders/{webhookData.ProductionWorkOrderId}?$access_token={accessToken}&$format=json";
            var response = await _httpClient.GetAsync(apiUrl);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                var jsonResponse = await response.Content.ReadAsStringAsync();
                
                // Deserialize the JSON into the WorkOrder class
                var workOrder = JsonSerializer.Deserialize<WorkOrder>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Makes the deserialization case insensitive
                });
                
                //return workOrder; // Return the populated WorkOrder object
                System.Console.WriteLine(workOrder?.ProductionWorkOrder?.Quantity);
            }
            else {
                // Handle errors, possibly throw an exception or return null
                throw new Exception($"Failed to fetch production work order data. Status code: {response.StatusCode}");
            }

            return 0;
        }
    }
}
