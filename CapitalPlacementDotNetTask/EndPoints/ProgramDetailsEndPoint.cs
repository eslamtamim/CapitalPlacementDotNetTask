using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CapitalPlacementDotNetTask.Models;
using CapitalPlacementDotNetTask.Data;
using FluentValidation;
using AutoMapper;


namespace CapitalPlacementDotNetTask.EndPoints;

public static class ProgramDetailsEndPoint
{
    public static void MapProgramDetailsEndPoints(this WebApplication app)
    {

        app.MapPost("/programs", POST_Program).WithName("PostProgram").Produces<ProgramModel>(200);
        app.MapPut("/programDetails/{id:guid}", PUT_ProgramDetails).WithName("UpdateProgramDetails");
        app.MapGet("/programDetails/{id:guid}", GET_ProgramDetails);


        //just for testing
        app.MapGet("/programs/{id:guid}", GET_Program).WithName("GetProgram").Produces<ProgramModel>(200);
        app.MapGet("/programs", GET_Programs).WithName("GetPrograms").Produces<IEnumerable<ProgramModel>>(200);

    }


 
    public static async Task<IResult> POST_Program([FromBody] ProgramDetails programDetails,
                                                          CosmosDataBaseContext _dbContext,
                                                          IValidator<ProgramDetails> validator)
    {
        var validationResult = await validator.ValidateAsync(programDetails);
        if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);
        var programModel = new ProgramModel
        {
            // the other properties of the ProgramModel remain empty untill you fill them with their 'PUT' EndPoint.
            ProgramDetails = programDetails,
        };

        // saving the program to the database with the "programDetails" Page only for now.
        await _dbContext.Programs.AddAsync(programModel);
        await _dbContext.SaveChangesAsync();
        return Results.CreatedAtRoute("GetProgram", new { id = programModel.Id }, programModel);
    }


    public static async Task<IResult> PUT_ProgramDetails(string id,[FromBody] ProgramDetails programDetails, CosmosDataBaseContext _dbContext, IValidator<ProgramDetails> validator)
    {
        if (string.IsNullOrWhiteSpace(id)) return Results.BadRequest("Id is invalide");

        var validationResult = await validator.ValidateAsync(programDetails);
        if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);
        
        var programModel = _dbContext.Programs.FirstOrDefault(p => p.Id == id);
        if (programModel is null) return Results.NotFound("No Program Found With This Id");
        
        programModel.ProgramDetails = programDetails;
        _dbContext.Programs.Update(programModel);
        await _dbContext.SaveChangesAsync();
        return Results.NoContent();
    }


    public static async Task<IResult> GET_ProgramDetails(string id, CosmosDataBaseContext _dbContext)
    {
        if (string.IsNullOrWhiteSpace(id)) return Results.BadRequest("Id is invalide");
        
        var programModel = await _dbContext.Programs.FirstOrDefaultAsync(p => p.Id == id);
        if (programModel is null) return Results.NotFound();

        var proramDetails = programModel.ProgramDetails;
        return Results.Ok(proramDetails);

    }


    public static async Task<IResult> GET_Program(string id, CosmosDataBaseContext _dbContext)
    {
        if (string.IsNullOrWhiteSpace(id)) return Results.BadRequest();
        var program = await _dbContext.Programs.FirstOrDefaultAsync(p => p.Id == id);
        return program is null ? Results.NotFound() : Results.Ok(program);
    }


    public static async Task<IResult> GET_Programs(CosmosDataBaseContext _dbContext)
    {
        var programs = await _dbContext.Programs.ToListAsync();
        if (programs is null) return Results.NotFound();
        if (!programs.Any()) return Results.NoContent();
        return Results.Ok(programs);
    }

  

}
