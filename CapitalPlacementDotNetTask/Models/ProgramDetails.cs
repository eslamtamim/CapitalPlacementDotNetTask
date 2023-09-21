namespace CapitalPlacementDotNetTask.Models;

public class ProgramDetails
{


    public required string Title { get; set; }
    public string? Summary { get; set; }
    public required string Description { get; set; }
    public List<string> KeySkills { get; set; } = new();
    public string? Benefits { get; set; }
    public string? ApplicationCriteria { get; set; }
    public required AdditionalProgramInformation AdditionalProgramInformation { get; set; }


}
