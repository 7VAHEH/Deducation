//using System;
//using System.Collections.Generic;

//namespace DeducationApi.Models;

//public partial class Education
//{
//    public int Id { get; set; }

//    public int UserId { get; set; }

//    public int UniversityId { get; set; }

//    public string? Degree { get; set; }

//    public string? FieldOfStudy { get; set; }

//    public DateTime? StartDate { get; set; }

//    public DateTime? EndDate { get; set; }

//    public string? Description { get; set; }

//    public DateTime? CreatedAt { get; set; }

//    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();

//    public virtual University University { get; set; }
//}
