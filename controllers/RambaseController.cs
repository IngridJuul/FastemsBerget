using Microsoft.AspNetCore.Mvc;
using FastemsBerget.Models;
using FastemsBerget.Services;
using RamBase.Api.Sdk;
using RamBaseApiSdk.Authentication;
using RamBase.Api.Sdk.Request;
using RamBase.Api.Sdk.Authentication;

namespace FastemsBerget.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkOrderController : ControllerBase
    {
        private readonly IWorkOrderService _workOrderService;

        public WorkOrderController(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        // This Endpoint will trigger when the release production workorder event is triggerd in rambase.
        [HttpPost("WorkOrderStarted")]
        public async Task<IActionResult> WorkOrderStarted([FromBody] WorkOrderWebhook webhookData)
        {
            // the post call needs to send in a Json object that matches WorkOrderWebhook, if not we return BadRequest.
            if (webhookData == null)
            {
                return BadRequest("Invalid data received from webhook.");
            }

            // Authenticate login to Rambase to get a valid access token.
            string target = "BERGET_TEST";
            var clientId = Environment.GetEnvironmentVariable("RAMBASE_CLIENT_ID");
            var clientSecret = Environment.GetEnvironmentVariable("RAMBASE_CLIENT_SECRET");

            RamBaseApi rbAPI = new RamBaseApi(clientId, clientSecret);
            try{
                rbAPI.LoginWithClientCredentialsAsync("","",target).GetAwaiter().GetResult();
            }
            catch(UnauthorizedException ex)
            {
                throw new Exception(ex.Message);
            }
            catch(RequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (LoginException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            // With accesstoken recived we make a get call to rambase to retrive the whole productionworkorder object. 
            try
            {
                WorkOrder result = await _workOrderService.getRbProductionWorkOrder(webhookData, rbAPI.AccessToken);

                // Return appropriate response
                return Ok("Hei hei alle sammen: " +result);
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            
        }
    }
}