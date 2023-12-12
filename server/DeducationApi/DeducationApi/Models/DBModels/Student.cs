using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeducationApi.Models.DBModels;

public partial class Student
{
    [Key]
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime Birthdate { get; set; }

    public string Country { get; set; }

    public string Faculty { get; set; }
    
    public string ClassOf { get; set; }

    public string Preferences { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public string? UniversityName { get; set; }

}
