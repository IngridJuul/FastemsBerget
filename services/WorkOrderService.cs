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
            


/*             if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve work order data");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var workOrderDetails = JsonSerializer.Deserialize<WorkOrderDetails>(jsonData);

            // Process the data and send it to another web service
            var processedWorkOrder = new ProcessWorkOrder
            {
                WorkOrderId = webhookData.WorkOrderId,
                DetailedInfo = workOrderDetails.DetailedInfo,
                Timestamp = DateTime.UtcNow
            };

            // Now send it to the target web service
            var targetUrl = "https://anotherwebservice.com/api/endpoint";
            var content = new StringContent(JsonSerializer.Serialize(processedWorkOrder));

            var sendResponse = await _httpClient.PostAsync(targetUrl, content);
            if (!sendResponse.IsSuccessStatusCode)
            {
                throw new Exception("Failed to send work order data to target service");
            } */

            return 0;
        }
    }
}
