using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDo.Application.Common.Dto;

public class UpdateToDoTaskDto
{
    [Required]
    [MinLength(10)]
    [MaxLength(1000)]
    public string Task { get; set; } = string.Empty;
}
