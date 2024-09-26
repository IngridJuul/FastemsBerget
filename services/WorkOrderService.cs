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
            var apiUrl = $"https://rambaseapi.com/api/workorders/";
            var response = await _httpClient.GetAsync(apiUrl);

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
