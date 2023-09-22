namespace CapitalPlacementDotNetTask.Models.ApplecationFormPage;

public class PersonalInformation
{
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public Phone? Phone { get; set; }
    public Nationality? Nationality { get; set; }
    public CurrentResidence? CurrentResidence { get; set; }
    public IdNumber? IdNumber { get; set; }
    public DateOfBirth? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }
    public List<Question>? Questions { get; set; }

}

public record Phone(string Value, bool Internal = false, bool Hide = false);
public record Nationality(string Value, bool Internal = false, bool Hide = false);
public record CurrentResidence(string Value, bool Internal = false, bool Hide = false);
public record IdNumber(string Value, bool Internal = false, bool Hide = false);
public record DateOfBirth(DateTime Value, bool Internal = false, bool Hide = false);
public record Gender(string Value, bool Internal = false, bool Hide = false);
