using System.ComponentModel.DataAnnotations.Schema;

namespace CapitalPlacementDotNetTask.Models.ApplecationFormPage;

public class Question
{

    public enum QuestionType
    {
        Paragraph,
        ShortAnswer,
        YESorNO,
        DropDown,
        MultipleChoice,
        Date, Number, File, Video
    }

    public QuestionType Type { get; set; }
    public string? QuestionText { get; set; }
    public List<string>? Choices { get; set; }
    public int? MaxAllowedChoices { get; set; }
    public bool? IsOtherOptionEnabled { get; set; }
    public bool? DisqualifyWhenAnswerIsNo { get; set; }

}
