using api_task_challenge.Models;
using api_task_challenge.Repositories;
using System.Globalization;

namespace api_cinema_challenge.EndPoints
{
    public static class MappingApi
    {
        public static void ConfigureMappingApi(this WebApplication app)
        {
            app.MapGet("/mappings", GetMappings);
            app.MapGet("/mappings/{id}", GetMapping);
            app.MapPost("/mappings", AddMapping);
            app.MapPut("/mappings{id}", UpdateMapping);
            app.MapDelete("/mappings/{id}", DeleteMapping);
        }

        public static async Task<IResult> GetMappings(IToDoItemRepository repository)
        {
            try
            {
                var mappings = repository.GetMappings();
                return mappings != null ? Results.Ok(mappings) : Results.Problem("There are no mappings yet");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetMapping(int id, IToDoItemRepository repository)
        {
            try
            {
                var mapping = repository.GetMapping(id);
                return mapping != null ? Results.Ok(mapping) : Results.Problem($"There is no mapping with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> AddMapping(Mapping mapping, IToDoItemRepository repository)
        {
            try
            {
                var element = repository.AddMapping(mapping);
                return element != null ? Results.Created("https://localhost:7174/mappings", element) : Results.Problem("There is no mapping to be added");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> UpdateMapping(Mapping mapping, IToDoItemRepository repository)
        {
            try
            {
                var element = repository.UpdateMapping(mapping);
                return element != null ? Results.Ok(element) : Results.Problem($"There is no mapping with id of {mapping.Id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> DeleteMapping(int id, IToDoItemRepository repository)
        {
            try
            {
                var mapping = repository.DeleteMapping(id);
                return mapping != null ? Results.Ok(mapping) : Results.Problem($"There is no mapping with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
