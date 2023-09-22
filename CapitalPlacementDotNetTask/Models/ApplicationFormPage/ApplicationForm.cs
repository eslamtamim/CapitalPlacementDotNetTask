namespace CapitalPlacementDotNetTask.Models.ApplecationFormPage
{
    public class ApplicationForm
    {

        public string? CoverImage { get; set; }
        public PersonalInformation? PersonalInformation { get; set; } 
        public ApplicationProfile? ApplicationProfile { get; set; }
        public List<Question>? AdditionalQuestions { get; set; } 



    }
}
