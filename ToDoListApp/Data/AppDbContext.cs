using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priority>().HasKey(p => p.Level);
            modelBuilder.Entity<User>().HasMany(u => u.ToDoItems).WithOne(t => t.User).HasForeignKey(t => t.UserId);


            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice" },
                new User { Id = 2, Name = "Bob" },
                new User { Id = 3, Name = "Charlie" },
                new User { Id = 4, Name = "David" },
                new User { Id = 5, Name = "Eve" }
            );

            modelBuilder.Entity<Priority>().HasData(
                new Priority { Level = 1 },
                new Priority { Level = 2 },
                new Priority { Level = 3 },
                new Priority { Level = 4 },
                new Priority { Level = 5 }
            );

            modelBuilder.Entity<ToDoItem>().HasData(
                new ToDoItem { Id = 1, Title = "Task 1", Description = "Description for Task 1", IsCompleted = false, DueDate = DateTime.Now.AddDays(1), PriorityId = 1, UserId = 1 },
                new ToDoItem { Id = 2, Title = "Task 2", Description = "Description for Task 2", IsCompleted = true, DueDate = DateTime.Now.AddDays(2), PriorityId = 2, UserId = 2 },
                new ToDoItem { Id = 3, Title = "Task 3", Description = "Description for Task 3", IsCompleted = false, DueDate = DateTime.Now.AddDays(3), PriorityId = 3, UserId = 3 },
                new ToDoItem { Id = 4, Title = "Task 4", Description = "Description for Task 4", IsCompleted = true, DueDate = DateTime.Now.AddDays(4), PriorityId = 4, UserId = 4 },
                new ToDoItem { Id = 5, Title = "Task 5", Description = "Description for Task 5", IsCompleted = false, DueDate = DateTime.Now.AddDays(5), PriorityId = 5, UserId = 5 }
            );
        }
    }
}
