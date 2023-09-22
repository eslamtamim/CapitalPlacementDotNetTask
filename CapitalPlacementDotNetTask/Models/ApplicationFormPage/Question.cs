namespace CapitalPlacementDotNetTask.Models.ApplecationFormPage;

public class Question
{

    public enum QuestionType
    {
        Paragraph,
        ShortAnswer,
        YESorNO,
        DropDown,
        MultipuleChoice,
        Date, Number, File, Video
    }

    public Question()
    {
        if (this.Type == QuestionType.MultipuleChoice)
        {
            this.Choices = new List<string>();
            this.IsOtherOptionEnabled = false;
            MaxAllowedChoices = 0;
        }
        if (this.Type == QuestionType.DropDown)
        {
            this.Choices = new List<string>();
            this.IsOtherOptionEnabled = true;
        }
        if (this.Type == QuestionType.YESorNO)
            DisqualifyWhenAnswerIsNo = true;

        // the rest of the types doesn't need any initialization, just the QuestionText is enough

    }

    public QuestionType Type { get; set; }
    public string? QuestionText { get; set; }
    public List<string>? Choices { get; set; }
    public int? MaxAllowedChoices { get; set; }
    public bool? IsOtherOptionEnabled { get; set; }
    public bool? DisqualifyWhenAnswerIsNo { get; set; }

}



//public class MultipuleChoiceQuestion : Question
//{
//    public MultipuleChoiceQuestion()
//    {
//        this.Type = QuestionType.MultipuleChoice;
//    }
//    public List<string>? Choices { get; set; }
//    public int? MaxAllowedChoices { get; set; }
//    public bool? IsOtherOptionEnabled { get; set; }
//    public bool? DisqualifyWhenAnswerIsNo { get; set; }

//}


//public class DropDownQuestion : Question
//{
//    public DropDownQuestion()
//    {
//        this.Type = QuestionType.DropDown;
//    }
//    public List<string>? Choices { get; set; }
//    public bool? IsOtherOptionEnabled { get; set; }
//}

//public class YesOrNOQuestion : Question
//{
//    public YesOrNOQuestion()
//    {
//        this.Type = QuestionType.YESorNO;
//    }
//    public bool? DisqualifyWhenAnswerIsNo { get; set; }
//}