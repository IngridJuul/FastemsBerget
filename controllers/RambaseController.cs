using Microsoft.AspNetCore.Mvc;
using FastemsBerget.Models;
using FastemsBerget.Services;

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
            System.Console.WriteLine("work order id: " + webhookData.ProductionWorkOrderId);
            if (webhookData == null)
            {
                return BadRequest("Invalid data received from webhook.");
            }

            try
            {
                // Process the webhook data asynchronously
                var result = await _workOrderService.HandleWorkOrderStartedAsync(webhookData);

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