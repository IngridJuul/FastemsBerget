/* using Microsoft.AspNetCore.Mvc;


namespace FastemsBerget.Controllers
{
    [ApiController]
    [Route("[rbController]")]
    public class WorkOrderController : ControllerBase
    {
        private readonly IWorkOrderService _workOrderService;

        public WorkOrderController(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        // Update the method to accept the new model with two parameters
        [HttpPost("WorkOrderStarted")]
        public async Task<IActionResult> WorkOrderStarted([FromBody] WorkOrderWebhook webhookData)
        {
            if (webhookData == null || string.IsNullOrEmpty(webhookData.ProductionWorkOrderId))
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
 */