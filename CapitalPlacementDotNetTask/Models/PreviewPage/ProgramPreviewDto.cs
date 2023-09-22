using CapitalPlacementDotNetTask.Models.ProgramDetailsPage;

namespace CapitalPlacementDotNetTask.Models.PreviewPage
{
    public class ProgramPreviewDto
    {


        public required ProgramDetailsDto programDetails { get; set; }
        public AdditionalProgramInformationDto AdditionalProgramInformation { get; set; }
    }
}
