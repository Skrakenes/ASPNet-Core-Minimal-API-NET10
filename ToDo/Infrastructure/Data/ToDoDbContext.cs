using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Infrastructure.Data.Enteties;

namespace ToDo.Infrastructure.Data;

public class ToDoDbContext : DbContext
{
    public required DbSet<ToDoTask> ToDoTasks { get; set; }
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ToDoDbContext).Assembly);
    }
}
