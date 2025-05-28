using Microsoft.AspNetCore.Identity;

namespace BlazorTodoApp.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }

        public DateTime? CreatedAt { get; set; }

        public ICollection<Todo>? Todos { get; set; }
    }
}
