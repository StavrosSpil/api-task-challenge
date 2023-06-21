using api_task_challenge.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace api_task_challenge.Data
{
    public class ToDoItemContext : DbContext
    {
        private static string GetConnectionString()
        {
            string jsonSettings = File.ReadAllText("appsettings.json");
            JObject configuration = JObject.Parse(jsonSettings);
            return configuration["ConnectionStrings"]["DefaultConnectionString"].ToString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(GetConnectionString());
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Mapping> Mappings { get; set; }
    }
}
