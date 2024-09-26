namespace FastemsBerget.Models
{    public class WorkOrderDetails
    {
        public string DetailedInfo { get; set; }
        // Add fields representing the detailed data you retrieve
    }

    public class ProcessWorkOrder
    {
        public string WorkOrderId { get; set; }
        public string DetailedInfo { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
