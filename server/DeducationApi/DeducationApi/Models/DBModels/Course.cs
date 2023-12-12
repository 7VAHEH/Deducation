using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeducationApi.Models.DBModels;

public partial class Course
{
    [Key]
    public Guid Id { get; set; }

    public Guid? UniversityId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Credits { get; set; }

    public string Instructor { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual University? University { get; set; }
}
