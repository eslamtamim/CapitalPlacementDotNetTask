using CapitalPlacementDotNetTask.Data;
using CapitalPlacementDotNetTask.Models.ApplecationFormPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapitalPlacementDotNetTask.EndPoints
{
    public static class ApplicationFormEndPoints
    {

        public static void MapApplicationFormEndPoints(this WebApplication app)
        {
            app.MapPut("/applicationForm/{id:guid}", PUT_ApplicationForm).Produces(204);
            app.MapGet("/applicationForm/{id:guid}", GET_ApplicationForm).Produces<ApplicationForm>(200);
        }


        private static async Task<IResult> PUT_ApplicationForm(string id, [FromBody] ApplicationForm applicationForm, CosmosDataBaseContext _dbContext)
        {
           
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

    }
}
