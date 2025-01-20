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

       struct RBiWorkOrder
// Input til programmet fra RB, data hentet i første GET WO
{
    public int RBiWorkOrderId ;
    public int RBiStatus ;
    public string? RBiType;
    public DateTime RBiCreatedAt;
    public DateTime RBiUpdatedAt;
    public DateTime RBiRegistrationDate;
    public string? RBiCustomersReferenceNumber;
    public double RBiNetWeight;
    public DateTime RBiRequestedCompletionDate;
    public DateTime? RBiConfirmedCompletionDate;
    public bool RBiIsConfirmedCompletionDateLocked;
    public string? RBiProductRevision;
    public double RBiQuantity;
    public DateTime? RBiScheduledStartDate;
    public DateTime? RBiScheduledCompletionDate;
    public string? RBiDueDateAndTime;
    public DateTime?RBiEstimatedStartDate;
    public double RBiRemainingQuantity;
    public double RBiPotentialProductionQuantity;
    public bool RBiHasMaterialShortage;
    public int? RBiMaterialDelayedDays;
    public bool RBiIsBlockedForPurchase;
    public bool RBiHasPriority;
    public bool RBiIsRework;
    public string? RBiCustomersReference;
    public DateTime RBiLatestStartAt;
    public double RBiAvailableQuantity;
    public double RBiAvailableQuantityInPercent;
    public bool RBiHasProcessRunning;
    public bool RBiIsInFaultyState;
    public bool RBiNeedsMaterialReplacementToRelease;
    public bool RBiIsManufacturedInBatches;
    public bool RBiIsBlockedForProduction;
    public string? RBiNote;
    public bool RBiHasStandardStructure;
    public string? RBiManufacturedProductName;
    public string? RBiPlanningCategory;
    public string? RBiProductUnitMarkingSpecification;
    public OnHold? RBiOnHold;
    public ProductionFor? RBiProductionFor;
    public Location? RBiLocation;
    public MeasurementUnit? RBiMeasurementUnit;
    public Product? RBiProduct;
    public Price? RBiPrice;
    public ProductStructure? RBiProductStructure;
    public FinanceProject? RBiFinanceProject;
    public Department? RBiDepartment;
    public ProductionPlanner? RBiProductionPlanner;
    public InitialWorkOrder? RBiInitialWorkOrder;
    public ForwardedFrom? RBiForwardedFrom;
    public Scrap? RBiScrap;
    public ManufacturingArea? RBiManufacturingArea;
    public Management? RBiManagement;
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
                    RBiWorkOrder RBiWOinp = new RBiWorkOrder();
                    Boolean FMopprett = true;
                    System.Console.WriteLine(workOrder?.ProductionWorkOrder?.Quantity);
                    System.Console.WriteLine(workOrder?.ProductionWorkOrder?.ScheduledStartDate);
                    // Henter ut de dataene som trengs fra WO RB til Fastems
                    RBiWOinp.RBiWorkOrderId = workOrder.ProductionWorkOrder.ProductionWorkOrderId;
                    RBiWOinp.RBiStatus = workOrder.ProductionWorkOrder.Status;
                    RBiWOinp.RBiScheduledCompletionDate = workOrder.ProductionWorkOrder.ScheduledCompletionDate;
                    RBiWOinp.RBiQuantity = workOrder.ProductionWorkOrder.Quantity;
                    // Sjekke datoformat til Fastems, legge til tid
                    // Står ikke i dokumentasjonen at dat må være eter dagens dato? 
                    string RBiTime = "T23:59:59"; 
                    RBiWOinp.RBiDueDateAndTime = RBiWOinp.RBiScheduledCompletionDate + RBiTime;
                    // Sjekke kvantum
                    if (RBiWOinp.RBiQuantity == 0.00) {
                        FMopprett = false;
                    }
                    if(FMopprett) {
                        // Koble opp mot Fastems? Eller skal det gjøres først?
                        // Flytte felter til Fastems Struktur?
                        // Kalle Fastems API

                    }
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
