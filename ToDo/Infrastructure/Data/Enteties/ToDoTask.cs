using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Infrastructure.Data.Enteties;

public class ToDoTask
{
    public int Id { get; set; }
    public string Task { get; set; } = string.Empty;

    public DateTime Created { get; set; }
    public DateTime? Deleted { get; set; }

}
