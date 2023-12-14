using Microsoft.EntityFrameworkCore;
using TodoListApp.Entities;

namespace TodoListApp.Models.EntityFramework
{
    public class Context : DbContext
    {
        public Context()
        {
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
                
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
