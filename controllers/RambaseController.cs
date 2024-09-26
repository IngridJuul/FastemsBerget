using Microsoft.AspNetCore.Mvc;
using FastemsBerget.Models;
using FastemsBerget.Services;

namespace YourProjectName.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            if (webhookData == null)
            {
                return BadRequest("Invalid data received from webhook.");
            }

            try
            {
                // Process the webhook data asynchronously
                var result = await _workOrderService.HandleWorkOrderStartedAsync(webhookData);

                // Return appropriate response
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}