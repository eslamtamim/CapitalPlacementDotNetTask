namespace CapitalPlacementDotNetTask.Models.PreviewPage
{
    public class AdditionalProgramInformationDto
    {

        public required string Type { get; set; }

        public DateTime? ProgramStartDate { get; set; }
        public DateTime ProgramOpenDate { get; set; }
        public DateTime ProgramCloseDate { get; set; }
        public string? Duration { get; set; }

        public required string Location { get; set; }
        public bool IsLocationRemote { get; set; } = false;


    }
}