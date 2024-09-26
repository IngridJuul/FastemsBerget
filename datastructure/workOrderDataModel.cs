public class WorkOrder
{
    public ProductionWorkOrder? ProductionWorkOrder { get; set; }
}

public class ProductionWorkOrder
{
    public int ProductionWorkOrderId { get; set; }
    public int Status { get; set; }
    public string? Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string? CustomersReferenceNumber { get; set; }
    public double NetWeight { get; set; }
    public DateTime RequestedCompletionDate { get; set; }
    public DateTime? ConfirmedCompletionDate { get; set; }
    public bool IsConfirmedCompletionDateLocked { get; set; }
    public string? ProductRevision { get; set; }
    public double Quantity { get; set; }
    public DateTime? ScheduledStartDate { get; set; }
    public DateTime? ScheduledCompletionDate { get; set; }
    public DateTime?EstimatedStartDate { get; set; }
    public double RemainingQuantity { get; set; }
    public double PotentialProductionQuantity { get; set; }
    public bool HasMaterialShortage { get; set; }
    public int? MaterialDelayedDays { get; set; }
    public bool IsBlockedForPurchase { get; set; }
    public bool HasPriority { get; set; }
    public bool IsRework { get; set; }
    public string? CustomersReference { get; set; }
    public DateTime LatestStartAt { get; set; }
    public double AvailableQuantity { get; set; }
    public double AvailableQuantityInPercent { get; set; }
    public bool HasProcessRunning { get; set; }
    public bool IsInFaultyState { get; set; }
    public bool NeedsMaterialReplacementToRelease { get; set; }
    public bool IsManufacturedInBatches { get; set; }
    public bool IsBlockedForProduction { get; set; }
    public string? Note { get; set; }
    public bool HasStandardStructure { get; set; }
    public string? ManufacturedProductName { get; set; }
    public string? PlanningCategory { get; set; }
    public string? ProductUnitMarkingSpecification { get; set; }
    public OnHold? OnHold { get; set; }
    public ProductionFor? ProductionFor { get; set; }
    public Location? Location { get; set; }
    public MeasurementUnit? MeasurementUnit { get; set; }
    public Product? Product { get; set; }
    public Price? Price { get; set; }
    public ProductStructure? ProductStructure { get; set; }
    public FinanceProject? FinanceProject { get; set; }
    public Department? Department { get; set; }
    public ProductionPlanner? ProductionPlanner { get; set; }
    public InitialWorkOrder? InitialWorkOrder { get; set; }
    public ForwardedFrom? ForwardedFrom { get; set; }
    public Scrap? Scrap { get; set; }
    public ManufacturingArea? ManufacturingArea { get; set; }
    public Management? Management { get; set; }
}

public class OnHold
{
    public bool IsOnHold { get; set; }
    public DateTime? OnHoldAt { get; set; }
    public DateTime? OnHoldTo { get; set; }
    public string? Category { get; set; }
    public string? CausedBy { get; set; }
    public string? Reason { get; set; }
}

public class ProductionFor
{
    public string? Database { get; set; }
    public int ItemId { get; set; }
    public string? ItemType { get; set; }
    public ObjectData? Object { get; set; }
    public string? RamBaseKey { get; set; }
    public string? ItemLink { get; set; }
    public DateTime? ConfirmedDeliveryDate { get; set; }
}

public class ObjectData
{
    public int? ObjectId { get; set; }
    public string? ObjectType { get; set; }
    public Customer? Customer { get; set; }
    public string? ObjectLink { get; set; }
}

public class Customer
{
    public int? CustomerId { get; set; }
    public string? Name { get; set; }
    public string? CustomerLink { get; set; }
}

public class Location
{
    public string? ShortName { get; set; }
}

public class MeasurementUnit
{
    public int? MeasurementUnitId { get; set; }
    public string? Unit { get; set; }
    public string? MeasurementUnitLink { get; set; }
}

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? CountryOfOriginCode { get; set; }
    public string? CustomField1 { get; set; }
    public string? CustomField2 { get; set; }
    public Dimensions? Dimensions { get; set; }
    public Manufacturer? Manufacturer { get; set; }
    public ProductClassification? ProductClassification { get; set; }
    public string? ProductLink { get; set; }
}

public class Dimensions
{
    public double? Weight { get; set; }
}

public class Manufacturer
{
    public int? ManufacturerId { get; set; }
    public string? ShortName { get; set; }
    public string? ManufacturerLink { get; set; }
}

public class ProductClassification
{
    public string? ProductClassificationId { get; set; }
    public string? ProductClassificationLink { get; set; }
}

public class Price
{
    public double? GrossPrice { get; set; }
    public string? Currency { get; set; }
}

public class ProductStructure
{
    public int? ProductStructureId { get; set; }
    public string? ProductStructureLink { get; set; }
}

public class FinanceProject
{
    public int? FinanceProjectId { get; set; }
    public string? FinanceProjectLink { get; set; }
}

public class Department
{
    public int DepartmentId { get; set; }
    public string? DepartmentLink { get; set; }
}

public class ProductionPlanner
{
    public int? EmployeeId { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? EmployeeLink { get; set; }
}

public class InitialWorkOrder
{
    public int? ProductionWorkOrderId { get; set; }
    public string? ProductionWorkOrderLink { get; set; }
}

public class ForwardedFrom
{
    public double? ForwardedQuantity { get; set; }
    public ForwardedFromItem? ForwardedFromItem { get; set; }
}

public class ForwardedFromItem
{
    public int? ItemId { get; set; }
    public ObjectData? Object { get; set; }
    public string? ItemLink { get; set; }
}

public class Scrap
{
    public bool IsScrapped { get; set; }
    public string? Reason { get; set; }
}

public class ManufacturingArea
{
    public int ManufacturingAreaId { get; set; }
    public string? Name { get; set; }
    public string? ManufacturingAreaLink { get; set; }
}

public class Management
{
    public ProjectLeader? ProjectLeader { get; set; }
    public DocumentController? DocumentController { get; set; }
}

public class ProjectLeader
{
    public int? EmployeeId { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? EmployeeLink { get; set; }
}

public class DocumentController
{
    public int? EmployeeId { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? EmployeeLink { get; set; }
}
