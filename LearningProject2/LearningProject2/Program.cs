using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using LearningProject2.Data;
using LearningProject2.Interfaces;
using LearningProject2.Models;
using LearningProject2.Properties;
using LearningProject2.Repositories;
using LearningProject2.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//Configuration services
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
//builder.Services.AddSingleton<IValidateOptions<AppSettings>, AppSettingsValidation>();



//"CONNECTION_STRING_DB
//Getting my connection string
var connectionString = builder.Configuration.GetConnectionString("BandDatabase");
//Initialise my DbContext inside the DI Container
builder.Services.AddDbContext<DataContext>(options
    => options.UseNpgsql(connectionString));





    builder.Services.AddScoped<IBandService, BandService>();
    builder.Services.AddScoped<IBandRepository, BandRepository>();

    builder.Services.AddControllers()
        .AddNewtonsoftJson(options => {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            options.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ";
        });


    builder.Services.AddHealthChecks();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddRouting();
    builder.Services.AddHttpClient();


    builder.Services.AddCors(options => {
        options.AddPolicy("AllowAllOrigins",
            builder => {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
    });

    var app = builder.Build();

    app.MapControllers();
    app.UseCors("AllowAllOrigins");
    app.UseRouting();
    app.UseHttpsRedirection();
    app.Run();



//builder.Services.ConfigureHttpJsonOptions(options =>
//{
//    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.DEFAULT);



//Anterior Jason
/*
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext );
    
    
});*/


 



 //Config for sql



//builder.Services.AddDbContext<DataContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
//});

  //builder.Services.AddDbContext<DataContext>(options =>
    //  options.UseNpgsql(builder.Configuration["CONNECTION_STRING"]));


/*
var sampleTodos = new Todo[]
{
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());
        
        


public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);
*/
//[JsonSerializable(typeof(Todo[]))]
//internal partial class AppJsonSerializerContext : JsonSerializerContext
//{
//}
/*
public class AppJsonSerializerContext
{
    
    
}*/