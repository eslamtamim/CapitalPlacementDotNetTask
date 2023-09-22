using CapitalPlacementDotNetTask.Models.ProgramDetailsPage;

namespace CapitalPlacementDotNetTask.Dtos.PreviewPageDTOs
{
    public class ProgramPreviewDto
    {


        public required ProgramDetailsDto programDetails { get; set; }
        public AdditionalProgramInformationDto AdditionalProgramInformation { get; set; }
    }
}
