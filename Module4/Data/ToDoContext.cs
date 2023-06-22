using Microsoft.EntityFrameworkCore;
using Module4.Models;

namespace Module4.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();
        }
        public DbSet<ToDoItem> ToDoItems { get; set; } = null!;
    }
}
