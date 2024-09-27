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
        Task<WorkOrder> getRbProductionWorkOrder(WorkOrderWebhook webhookData, string accessToken);
    }

    public class WorkOrderService : IWorkOrderService
    {
        private readonly HttpClient _httpClient;

        public WorkOrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Makes a call to rambase and gets the prodcution work order object from the given productionworkorderID.
        // Takes two parameters: productionworkorderID and accessToken  
        public async Task<WorkOrder> getRbProductionWorkOrder(WorkOrderWebhook webhookData, string accessToken)
        {
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
                
                if(workOrder != null){
                    System.Console.WriteLine(workOrder?.ProductionWorkOrder?.Quantity);
                    return workOrder;
                }
                else{
                    throw new Exception($"Unable to deserialize return object to a WorkOrder object. WorkOrder is null.");
                }
            }
            else {
                // Handle errors, possibly throw an exception or return null
                throw new Exception($"Failed to fetch production work order data. Status code: {response.StatusCode}");
            }
        }
    }
}
