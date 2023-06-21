using api_task_challenge.Models;

namespace api_task_challenge.Repositories
{
    public interface IToDoItemRepository
    {
        ToDoItem AddToDoItem(ToDoItem item);
        IEnumerable<ToDoItem> GetToDoItems();
        ToDoItem GetToDoItem(int id);
        ToDoItem UpdateToDoItem(ToDoItem item);
        ToDoItem DeleteToDoItem(int id);

        User AddUser(User user);
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        User UpdateUser(User user);
        User DeleteUser(int id);

        Mapping AddMapping(Mapping mapping);
        IEnumerable<Mapping> GetMappings();
        Mapping GetMapping(int id);
        Mapping UpdateMapping(Mapping mapping);
        Mapping DeleteMapping(int id);

    }
}
