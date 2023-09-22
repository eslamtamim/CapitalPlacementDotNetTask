using AutoMapper;
using CapitalPlacementDotNetTask.Data;
using CapitalPlacementDotNetTask.Dtos.PreviewPageDTOs;

namespace CapitalPlacementDotNetTask.EndPoints
{
    public static class ProgramPreviewEndPoints
    {


        public static void MapProgramPreviewEndPoint(this WebApplication app)
        {
            app.MapGet("/preview/{id:guid}", GET_ProgramPreview);
        }

        private static async Task<IResult> GET_ProgramPreview(string id, CosmosDataBaseContext _dbContext, IMapper mapper)
        {

            var programModel = await _dbContext.Programs.FindAsync(id);
            if (programModel == null) return Results.NotFound("No Program found with this Id");
            var programPreviewDto = new ProgramPreviewDto
            {
                programDetails = mapper.Map<ProgramDetailsDto>(programModel.ProgramDetails),
                AdditionalProgramInformation = mapper.Map<AdditionalProgramInformationDto>(programModel.ProgramDetails.AdditionalProgramInformation)
            };

            return Results.Ok(programPreviewDto);
        }
    }

}
