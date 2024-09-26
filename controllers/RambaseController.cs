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

        [HttpPost("WorkOrderStarted")]
        public async Task<IActionResult> WorkOrderStarted([FromBody] WorkOrderWebhook webhookData)
        {
            string target = "BERGET_TEST";
            string clientId = "MRrvDw7520eEpU5eT4Yi0Q2";
            string secret = "fW9pDegD9UOiDYy84IfoZA2";
            RamBaseApi rbAPI = new RamBaseApi(clientId, secret);
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
            System.Console.WriteLine(rbAPI.AccessToken);
            System.Console.WriteLine("work order id: " + webhookData.ProductionWorkOrderId);
            if (webhookData == null)
            {
                return BadRequest("Invalid data received from webhook.");
            }

            try
            {
                // Process the webhook data asynchronously
                var result = await _workOrderService.HandleWorkOrderStartedAsync(webhookData, rbAPI.AccessToken);

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