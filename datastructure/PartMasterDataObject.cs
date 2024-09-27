public class PartMasterDataObject
{
    public string? Name { get; set; }
    public string?Description { get; set; }    
    public string? ItemType { get; set; }
    public string? Material { get; set; }
    public Boolean Locked { get; set; }
    public List<string>? Documents { get; set; }
    public List<OperationsObject>? Operations { get; set; }
}
public class OperationsObject
{
    public string? Discriminator { get; set; }
    public int OperationNumber { get; set; }
    public string? OperationDescription { get; set; }
    public ProcessPlan? processPlan { get; set; }
    public List<string>? Documents { get; set; }
}
public class ProcessPlan
{
    public string? WorkUnitTypeName { get; set; }
    public List<string>? AllowedWorkUnits{ get; set; }
    public int SchedulingStartPermissionQuantity { get; set; }
    public int BatchSize { get; set; }
    public TimeSpan BatchPreparationDuration { get; set; }
    public TimeSpan DurationPerPart { get; set; }
}