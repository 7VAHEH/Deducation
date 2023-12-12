using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeducationApi.Models.DBModels;

public partial class University
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public string Description { get; set; }

    public string Password { get; set; }

    public string Website { get; set; }

    public string EducationalSystemInfo { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? EducationalProgramUrl { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
