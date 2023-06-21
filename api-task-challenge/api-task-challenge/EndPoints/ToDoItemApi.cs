using api_task_challenge.Models;
using api_task_challenge.Repositories;
using System.Linq.Expressions;

namespace api_task_challenge.EndPoints
{
    public static class ToDoItemApi
    {
        public static void ConfigureToDoItemApi(this WebApplication app)
        {
            app.MapGet("/tasks", GetToDoItems);
            app.MapGet("/tasks/{id}", GetToDoItem);
            app.MapPost("/tasks", AddToDoItem);
            app.MapPut("/tasks{id}", UpdateToDoItem);
            app.MapDelete("/tasks/{id}", DeleteToDoItem);
        }

        public static async Task<IResult> GetToDoItems(IToDoItemRepository repository)
        {
            try
            {
                var items = repository.GetToDoItems();
                return items != null ? Results.Ok(items) : Results.Problem("There are no tasks yet");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetToDoItem(int id, IToDoItemRepository repository)
        {
            try
            {
                var item = repository.GetToDoItem(id);
                return item != null ? Results.Ok(item) : Results.Problem($"There is no task with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> AddToDoItem(ToDoItem item, IToDoItemRepository repository)
        {
            try
            {
                var element = repository.AddToDoItem(item);
                return element != null ? Results.Created("https://localhost:7174/items", element) : Results.Problem("There is no task to be added");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> UpdateToDoItem(ToDoItem item, IToDoItemRepository repository)
        {
            try
            {
                var element = repository.UpdateToDoItem(item);
                return element != null ? Results.Ok(element) : Results.Problem($"There is no task with id of {item.Id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> DeleteToDoItem(int id, IToDoItemRepository repository)
        {
            try
            {
                var item = repository.DeleteToDoItem(id);
                return item != null ? Results.Ok(item) : Results.Problem($"There is no task with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
