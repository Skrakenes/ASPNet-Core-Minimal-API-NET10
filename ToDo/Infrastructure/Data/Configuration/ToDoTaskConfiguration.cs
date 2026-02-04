using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Infrastructure.Data.Enteties;

namespace ToDo.Infrastructure.Data.Configuration;

public class ToDoTaskConfiguration : IEntityTypeConfiguration<ToDoTask>
{
    public void Configure(EntityTypeBuilder<ToDoTask> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Task).HasMaxLength(100);

        builder.ToTable("ToDoTasks");
    }
}
