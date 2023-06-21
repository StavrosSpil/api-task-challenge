using api_task_challenge.Models;
using api_task_challenge.Repositories;

namespace api_task_challenge.EndPoints
{
    public static class UserApi
    {
        public static void ConfigureUserApi(this WebApplication app)
        {
            app.MapGet("/users", GetUsers);
            app.MapGet("/users/{id}", GetUser);
            app.MapPost("/users", AddUser);
            app.MapPut("/users{id}", UpdateUser);
            app.MapDelete("/users/{id}", DeleteUser);
        }

        public static async Task<IResult> GetUsers(IToDoItemRepository repository)
        {
            try
            {
                var users = repository.GetUsers();
                return users != null ? Results.Ok(users) : Results.Problem("There are no users yet");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetUser(int id, IToDoItemRepository repository)
        {
            try
            {
                var user = repository.GetUser(id);
                return user != null ? Results.Ok(user) : Results.Problem($"There is no user with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> AddUser(User user, IToDoItemRepository repository)
        {
            try
            {
                var element = repository.AddUser(user);
                return element != null ? Results.Created("https://localhost:7174/users", element) : Results.Problem("There is no user to be added");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> UpdateUser(User user, IToDoItemRepository repository)
        {
            try
            {
                var element = repository.UpdateUser(user);
                return element != null ? Results.Ok(element) : Results.Problem($"There is no user with id of {user.Id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> DeleteUser(int id, IToDoItemRepository repository)
        {
            try
            {
                var user = repository.DeleteUser(id);
                return user != null ? Results.Ok(user) : Results.Problem($"There is no user with id of {id}");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
