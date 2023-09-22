using CapitalPlacementDotNetTask.Models.ApplecationFormPage;
using CapitalPlacementDotNetTask.Models.ProgramDetailsPage;

namespace CapitalPlacementDotNetTask.Models;

public class ProgramModel
{

    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required ProgramDetails ProgramDetails { get; set; }

    public ApplicationForm? ApplicationForm { get; set; }
}
