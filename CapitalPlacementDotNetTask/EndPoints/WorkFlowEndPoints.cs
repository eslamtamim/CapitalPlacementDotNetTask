using AutoMapper;
using CapitalPlacementDotNetTask.Data;
using CapitalPlacementDotNetTask.Models.ApplecationFormPage;
using CapitalPlacementDotNetTask.Models.WorkFlowPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using static CapitalPlacementDotNetTask.Models.WorkFlowPage.Stage;

namespace CapitalPlacementDotNetTask.EndPoints
{
    public static class WorkFlowEndPoints
    {

        public static void MapWorkFlowEndPoints(this WebApplication app)
        {
            app.MapPut("/workFlow/{id:guid}", PUT_WorkFlow).Produces(204).AddEndpointFilter(PUT_WorkFlowFilter);


            app.MapGet("/workFlow/{id:guid}", GET_WorkFlow).Produces<WorkFlow>(200);
        }

      

        private static async Task<IResult> PUT_WorkFlow(string id, [FromBody] WorkFlow workFlow, CosmosDataBaseContext _dbContext)
        {
            var programModel = await _dbContext.Programs.FirstOrDefaultAsync(p => p.Id == id);
            if (programModel is null) return Results.NotFound("No Program Found With This Id");
            programModel.WorkFlow = workFlow;
            _dbContext.Programs.Update(programModel);
            await _dbContext.SaveChangesAsync();
            return Results.NoContent();
        }

        private static async Task<IResult> GET_WorkFlow(string id, CosmosDataBaseContext _dbContext)
        {
            var programModel = await _dbContext.Programs.FirstOrDefaultAsync(p => p.Id == id);
            if (programModel is null) return Results.NotFound("No Program Found With This Id");

            var workFlow = programModel.WorkFlow;
            if (workFlow is null) return Results.NoContent();
            return Results.Ok(workFlow);

        }

        private static async ValueTask<object?> PUT_WorkFlowFilter(EndpointFilterInvocationContext invocationContext, EndpointFilterDelegate @next)
        {
            var stages = invocationContext.GetArgument<WorkFlow>(1).Stages;
            if (stages is null) return await next(invocationContext);

            foreach (var stage in stages)
            {
                if (!Enum.IsDefined(typeof(StageType), stage.Type!)) return Results.BadRequest("Invalied type");
                if (stage.Type != Stage.StageType.VideoInterview && stage.VideoInterviewStage is not null)
                {
                    return Results.BadRequest("The type of the stage and the properties don't match");
                }
            }

            return await next(invocationContext);
        }
    }
}
