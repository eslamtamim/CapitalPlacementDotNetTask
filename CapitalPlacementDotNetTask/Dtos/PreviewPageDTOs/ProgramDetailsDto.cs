namespace CapitalPlacementDotNetTask.Dtos.PreviewPageDTOs
{
    public class ProgramDetailsDto
    {

        public required string Title { get; set; }
        public string? Summary { get; set; }
        public required string Description { get; set; }
        public List<string> KeySkills { get; set; } = new();
        public string? Benefits { get; set; }
        public string? ApplicationCriteria { get; set; }


    }
}