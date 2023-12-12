using System;
using System.Collections.Generic;
using DeducationApi.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace DeducationApi.Models;

public partial class DeducationDBContext : DbContext
{

    public DeducationDBContext(DbContextOptions<DeducationDBContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Employer> Employers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<University> Universities { get; set; }
}