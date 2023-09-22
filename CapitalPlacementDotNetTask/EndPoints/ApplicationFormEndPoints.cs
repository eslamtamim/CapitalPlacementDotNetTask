using AutoMapper;
using CapitalPlacementDotNetTask.Data;
using CapitalPlacementDotNetTask.Models.ApplecationFormPage;
using CapitalPlacementDotNetTask.Models.ProgramDetailsPage;
using CapitalPlacementDotNetTask.Models.WorkFlowPage;
using CapitalPlacementDotNetTask.Validatiors;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CapitalPlacementDotNetTask.Models.ApplecationFormPage.QuestionDto;
using static CapitalPlacementDotNetTask.Models.WorkFlowPage.Stage;

namespace CapitalPlacementDotNetTask.EndPoints
{
    public static class ApplicationFormEndPoints
    {

        public static void MapApplicationFormEndPoints(this WebApplication app)
        {

            app.MapPut("/applicationForm/{id:guid}", PUT_ApplicationForm).Produces(204).AddEndpointFilter(PUT_ApplicationFormFilter);

            app.MapGet("/applicationForm/{id:guid}", GET_ApplicationForm).Produces<ApplicationForm>(200);
        }



        private static async Task<IResult> PUT_ApplicationForm(string id, [FromBody] ApplicationForm applicationForm, CosmosDataBaseContext _dbContext, IValidator<ApplicationForm> validator)
        {

            var validationResult = await validator.ValidateAsync(applicationForm);
            if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);


            var programModel = await _dbContext.Programs.FirstOrDefaultAsync(p => p.Id == id);
            if (programModel is null) return Results.NotFound("No Program Found With This Id");

            programModel.ApplicationForm = applicationForm;

            _dbContext.Programs.Update(programModel);
            await _dbContext.SaveChangesAsync();

            return Results.NoContent();
        }

        private static async Task<IResult> GET_ApplicationForm(string id, CosmosDataBaseContext _dbContext)
        {
            var programModel = await _dbContext.Programs.FirstOrDefaultAsync(p => p.Id == id);
            if (programModel is null) return Results.NotFound("No Program Found With This Id");

            var applicationForm = programModel.ApplicationForm;
            if (applicationForm is null) return Results.NoContent();

            return Results.Ok(applicationForm);
        }




        private static async ValueTask<object?> PUT_ApplicationFormFilter(EndpointFilterInvocationContext invocationContext, EndpointFilterDelegate @next)
        {
            var questions = new List<QuestionDto>();
            questions.AddRange(invocationContext.GetArgument<ApplicationForm>(1).AdditionalQuestions!);
            foreach (var question in questions)
            {
                if (!Enum.IsDefined(typeof(QuestionType), question.Type!)) return Results.BadRequest("Invalied type");

                if (question.Type == QuestionType.MultipleChoice && question.DisqualifyWhenAnswerIsNo is not null)
                {
                    return Results.BadRequest($"The type of the question [{question.QuestionText}] and the properties don't match");
                }
                else if (question.Type == QuestionType.DropDown && (question.DisqualifyWhenAnswerIsNo is not null || question.MaxAllowedChoices is not null))
                {
                    return Results.BadRequest($"The type of the question [{question.QuestionText}] and the properties don't match");
                }
                else if (question.Type == QuestionType.YESorNO && (question.Choices is not null || question.Choices is not null || question.MaxAllowedChoices is not null))
                {
                    return Results.BadRequest($"The type of the question [{question.QuestionText}] and the properties don't match");
                }

            }
            return await next(invocationContext);

        }

    }
}
