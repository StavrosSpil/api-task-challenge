using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using api_task_challenge.EndPoints;
using api_task_challenge.Repositories;
using api_task_challenge.Data;
using api_cinema_challenge.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
builder.Services.AddDbContext<ToDoItemContext>();

//TODO: change the capitalized strings in the options to match your api and contact details
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TITLE_OF_PROJECT_API",
        Description = "DESCRIPTION_OF_API",
        Contact = new OpenApiContact
        {
            Name = "YOUR_NAME",
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .SetIsOriginAllowed(origin => true) // allow any origin
                 .AllowCredentials()); // allow credentials
}

app.ConfigureToDoItemApi();

app.ConfigureUserApi();

app.ConfigureMappingApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
