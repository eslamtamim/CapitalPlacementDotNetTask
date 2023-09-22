namespace CapitalPlacementDotNetTask.Models.WorkFlowPage
{
    public class Stage
    {
        public enum StageType
        {
            ShortListing,
            VideoInterview,
            Placement
        }
        public string? Name { get; set; }
        public StageType? Type { get; set; }
        public VideoInterviewStage? VideoInterviewStage { get; set; }
        public bool? IsShownToCandidate { get; set; }
    }

    public record VideoInterviewStage(string Question,string Information,int MaxDurationOfVideo,string VideoUnitOfTime,int DeadLineInDays);
}
