namespace CapitalPlacementDotNetTask.Models.ProgramDetailsPage;

public class AdditionalProgramInformation
{

    // im not sure if this should be a string, enums good but will be stored as ints in the database so im just going to use strings for now
    public required string Type { get; set; }

    public DateTime? ProgramStartDate { get; set; }
    public DateTime ProgramOpenDate { get; set; }
    public DateTime ProgramCloseDate { get; set; }
    public string? Duration { get; set; }

    public required string Location { get; set; }
    public bool IsLocationRemote { get; set; } = false;

    public string? MinQualifications { get; set; }
    public int? MaxNumberOfApplications { get; set; }
}
