using Microsoft.EntityFrameworkCore;
using ToDo_API.Models;

namespace ToDo_API
{
    public class ToDoDBContext : DbContext
    {
        public ToDoDBContext(DbContextOptions<ToDoDBContext> options): base(options)
        {

        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
