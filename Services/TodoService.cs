using BlazorTodoApp.Context;
using BlazorTodoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTodoApp.Services
{
    public class TodoService
    {
        private readonly AppDbContext _db;

        public TodoService(AppDbContext db)
        {
            _db = db;
        }

        // Get all todos
        public async Task<List<Todo>> GetAllTodosAsync(string userId)
        {
            return await _db.Todos.Where(t => t.UserId == userId).ToListAsync();
        }

        // Get a todo by id
        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _db.Todos.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
        }

        // Add a todo
        public async Task<bool> AddTodoAsync(Todo todo)
        {
            // Ensure the UserId is set and User is properly associated
            if (string.IsNullOrEmpty(todo.UserId))
            {
                throw new ArgumentException("Todo must have a UserId.");
            }

            var user = await _db.Users.FindAsync(todo.UserId);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            // Associate the user with the todo
            todo.User = user;

            await _db.Todos.AddAsync(todo);
            await _db.SaveChangesAsync();
            return true;
        }


        // Get todos for a specific user
        public async Task<List<Todo>> GetTodosForUserAsync(string userId)
        {
            return await _db.Todos
                            .Where(t => t.UserId == userId)
                            .Include(t => t.User)
                            .ToListAsync();
        }

        // Update a todo
        public async Task<bool> UpdateTodoAsync(Todo todo)
        {
            _db.Todos.Update(todo);
            await _db.SaveChangesAsync();
            return true;
        }

        // Delete a todo by id
        public async Task<bool> DeleteTodoByIdAsync(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo == null)
                return false;

            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
            return true;
        }

        // Delete a todo
        public async Task<bool> DeleteTodoAsync(Todo todo)
        {
            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
