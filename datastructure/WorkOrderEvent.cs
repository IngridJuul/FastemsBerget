namespace FastemsBerget.Models
{
    public class WorkOrderWebhook
    {
        public string WorkOrderId { get; set; }
        public string Event { get; set; }
        // Add other webhook-specific fields here
    }

    public class WorkOrderDetails
    {
        public string DetailedInfo { get; set; }
        // Add fields representing the detailed data you retrieve
    }

    public class ProcessedWorkOrder
    {
        public string WorkOrderId { get; set; }
        public string DetailedInfo { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
