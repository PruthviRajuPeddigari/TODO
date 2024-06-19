using Microsoft.EntityFrameworkCore;
using TODO.Data.Models;

namespace TODO.Data
{
    public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
    {
        public DbSet<TodoItem> Todos { get; set; }
    }
}
