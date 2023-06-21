using System.ComponentModel.DataAnnotations.Schema;

namespace api_task_challenge.Models
{
    public class Mapping
    {
        public int Id { get; set; }
        public bool Completed { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("ToDoItem")]
        public int ToDoItemId { get; set; }
        public ToDoItem ToDoItem { get; set; }
    }
}

