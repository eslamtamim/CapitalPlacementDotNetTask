using CapitalPlacementDotNetTask.Models.ProgramDetailsPage;
using FluentValidation;

namespace CapitalPlacementDotNetTask.Validatiors;

public class ProgramDetailsValidator : AbstractValidator<ProgramDetails>
{
    public ProgramDetailsValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(p => p.Summary).MaximumLength(250).WithMessage("Description can't be more than 250 character");
        RuleFor(p => p.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(p => p.AdditionalProgramInformation).NotNull().WithMessage("Program information is required");
        RuleFor(p => p.AdditionalProgramInformation.Type).NotEmpty().WithMessage("Program type is required");
        RuleFor(p => p.AdditionalProgramInformation.ProgramOpenDate).NotEmpty().WithMessage("Program open date is required");
        RuleFor(p => p.AdditionalProgramInformation.ProgramCloseDate).NotEmpty().WithMessage("Program end date is required");
        RuleFor(p => p.AdditionalProgramInformation.Location).NotEmpty().WithMessage("Location is required");
    }
}
