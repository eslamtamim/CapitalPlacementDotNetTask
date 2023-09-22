namespace CapitalPlacementDotNetTask.Models.ApplecationFormPage
{
    public class ApplicationProfile
    {

        public List<Education>? Education { get; set; }
        public List<Experience>? Experience { get; set; }
        public Resume? Resume { get; set; }
        public List<QuestionDto>? Questions { get; set; }
    }

    public record Education(string School, string Degree, string CourseName, string LocationOfStudy,
                            DateTime StartDate, DateTime EndDate, bool IsCurrentlyStudying = false, bool Mandatory = false, bool Hide = false);
    public record Experience(string Company, string Title, string LocationOfWork, DateTime StartDate, DateTime EndDate,
                             bool IsCurrentlyWorking = false, bool Mandatory = false, bool Hide = false);
    public record Resume(string Value, bool Mandatory = false, bool Hide = false);

}
