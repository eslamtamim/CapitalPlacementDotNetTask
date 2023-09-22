using CapitalPlacementDotNetTask.Models.ProgramDetailsPage;

namespace CapitalPlacementDotNetTask.Models.PreviewPage
{
    public class ProgramPreviewDto
    {


        public required ProgramDetails programDetails { get; set; }
        public AdditionalProgramInformationDto AdditionalProgramInformationDto { get; set; }
    }
}
