using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeducationApi.Models.DBModels;

public partial class Professor
{
    [Key]
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string FieldOfStudy { get; set; }

    public string Degree { get; set; }

    public DateTime YearGraduated { get; set; }

    public string CurrentPosition { get; set; }

    public string Institution { get; set; }

    public string TeachingExperience { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public Guid? UniversityId { get; set; }

    //public int? EducationId { get; set; }

    //public virtual Education? Education { get; set; }

    public virtual University University { get; set; } = null!;

}
