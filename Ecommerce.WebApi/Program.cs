using Ecommerce.Core;
using Ecommerce.Infrastructure;
using Ecommerce.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Add Infrastructure Layer
builder.Services.AddInfrastructure(builder.Configuration);
//add Core Layer
builder.Services.AddCore(builder.Configuration);

//Add Middlewares
builder.Services.AddScoped<ExceptionHandlingMiddleware>();
builder.Services.AddExceptionHandler(o =>
{
    o.ExceptionHandlingPath = "/error";
});
builder.Services.AddControllers();
var app = builder.Build();
app.UseExceptionHandlingMiddleware();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () =>
{
    throw new Exception("text");
});

app.MapGet("/ok", () => "ok");

app.Run();