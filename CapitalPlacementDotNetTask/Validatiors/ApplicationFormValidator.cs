using CapitalPlacementDotNetTask.Models.ApplecationFormPage;
using FluentValidation;

namespace CapitalPlacementDotNetTask.Validatiors
{
    public class ApplicationFormValidator : AbstractValidator<ApplicationForm>
    {
        public ApplicationFormValidator()
        {
            try
            {
                RuleFor(p => p.PersonalInformation.Email).EmailAddress().WithMessage("Provide a valied Email");
                RuleFor(p => p.PersonalInformation.Phone.Value).MaximumLength(11).WithMessage("PhoneNumber Should be 11 digits");
            }
            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
