using api_task_challenge.Data;
using api_task_challenge.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace api_task_challenge.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        public Mapping AddMapping(Mapping mapping)
        {
            using (var db = new ToDoItemContext())
            {
                db.Mappings.Add(mapping);
                db.SaveChanges();
                return mapping;
            }
        }

        public ToDoItem AddToDoItem(ToDoItem item)
        {
            using (var db = new ToDoItemContext())
            {
                db.ToDoItems.Add(item);
                db.SaveChanges();
                return item;
            }
        }

        public User AddUser(User user)
        {
            using (var db = new ToDoItemContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
        }

        public Mapping DeleteMapping(int id)
        {
            using (var db = new ToDoItemContext())
            {
                var mapping = db.Mappings.FirstOrDefault(i => i.Id == id);
                if (mapping != null)
                {
                    db.Mappings.Remove(mapping);
                    db.SaveChanges();
                    return mapping;
                }
                return null;
            }
        }

        public ToDoItem DeleteToDoItem(int id)
        {
            using (var db = new ToDoItemContext())
            {
                var item = db.ToDoItems.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    db.ToDoItems.Remove(item);
                    db.SaveChanges();
                    return item;
                }
                return null;
            }
        }

        public User DeleteUser(int id)
        {
            using (var db = new ToDoItemContext())
            {
                var user = db.Users.FirstOrDefault(i => i.Id == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return user;
                }
                return null;
            }
        }

        public Mapping GetMapping(int id)
        {
            using (var db = new ToDoItemContext())
            {
                var mapping = db.Mappings.Include(m => m.User).Include(m => m.ToDoItem).FirstOrDefault(i => i.Id == id);
                return mapping != null ? mapping : null;
            }
        }

        public IEnumerable<Mapping> GetMappings()
        {
            using (var db = new ToDoItemContext())
            {
                return db.Mappings.Include(m => m.User).Include(m => m.ToDoItem).ToList();
            }
        }

        public ToDoItem GetToDoItem(int id)
        {
            using (var db = new ToDoItemContext())
            {
                var item = db.ToDoItems.FirstOrDefault(i => i.Id == id);
                return item != null ? item : null;
            }
        }

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            using (var db = new ToDoItemContext())
            {
                return db.ToDoItems.ToList();
            }
        }

        public User GetUser(int id)
        {
            using (var db = new ToDoItemContext())
            {
                var user = db.Users.FirstOrDefault(i => i.Id == id);
                return user != null ? user : null;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var db = new ToDoItemContext())
            {
                return db.Users.ToList();
            }
        }

        public Mapping UpdateMapping(Mapping mapping)
        {
            using (var db = new ToDoItemContext())
            {
                db.Mappings.Update(mapping);
                db.SaveChanges();
                return mapping;
            }
        }

        public ToDoItem UpdateToDoItem(ToDoItem item)
        {
            using (var db = new ToDoItemContext())
            {
                db.ToDoItems.Update(item);
                db.SaveChanges();
                return item;
            }
        }

        public User UpdateUser(User user)
        {
            using (var db = new ToDoItemContext())
            {
                db.Users.Update(user);
                db.SaveChanges();
                return user;
            }
        }
    }
}
