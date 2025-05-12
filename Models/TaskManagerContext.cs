/*Responsibility of maping model to table in database after managing connection*/
using Microsoft.EntityFrameworkCore;

namespace TaskManagerApi.Models;

public class TaskManagerContext: DbContext{
    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
        : base(options)
    {}

    public DbSet<TaskItem> TaskItems {get; set;} = null!;

    //Seed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // For TaskItems
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Task 1", Status = "Pending", RequestTeam = "DevOps", ReceivingTeam = "Frontend", IsApproved = false, ReviewMessage = null },
                new TaskItem { Id = 2, Title = "Task 2", Status = "Active", RequestTeam = "Backend", ReceivingTeam = "Frontend", IsApproved = true, ReviewMessage = "Reviewed and approved" },
                new TaskItem { Id = 3, Title = "Task 3", Status = "Review", RequestTeam = "Frontend", ReceivingTeam = "Test", IsApproved = false, ReviewMessage = "Needs modifications" },
                new TaskItem { Id = 4, Title = "Task 4", Status = "Pending", RequestTeam = "DevOps", ReceivingTeam = "Backend", IsApproved = true, ReviewMessage = null },
                new TaskItem { Id = 5, Title = "Task 5", Status = "Active", RequestTeam = "Backend", ReceivingTeam = "DevOps", IsApproved = true, ReviewMessage = "Approved after review" },
                new TaskItem { Id = 6, Title = "Task 6", Status = "Pending", RequestTeam = "Frontend", ReceivingTeam = "Backend", IsApproved = false, ReviewMessage = "Review pending" },
                new TaskItem { Id = 7, Title = "Task 7", Status = "Review", RequestTeam = "DevOps", ReceivingTeam = "Frontend", IsApproved = true, ReviewMessage = "Reviewed successfully" },
                new TaskItem { Id = 8, Title = "Task 8", Status = "Pending", RequestTeam = "Backend", ReceivingTeam = "Frontend", IsApproved = false, ReviewMessage = "In review process" },
                new TaskItem { Id = 9, Title = "Task 9", Status = "Active", RequestTeam = "Test", ReceivingTeam = "Backend", IsApproved = true, ReviewMessage = null },
                new TaskItem { Id = 10, Title = "Task 10", Status = "Review", RequestTeam = "DevOps", ReceivingTeam = "Test", IsApproved = false, ReviewMessage = "Pending feedback" }
            );
        }
}