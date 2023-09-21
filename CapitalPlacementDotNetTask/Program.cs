var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", () => "Hello Capital Placement!");


app.UseHttpsRedirection();
app.Run();

