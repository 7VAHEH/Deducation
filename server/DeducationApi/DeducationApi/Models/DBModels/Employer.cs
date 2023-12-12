using System.ComponentModel.DataAnnotations;

namespace DeducationApi.Models.DBModels
{
    public class Employer
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonEmail { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public int Since { get; set; }
        public string CompanyIndustry { get; set; }
        public string LinkToProfile { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyLocation { get; set; }
        public string JobTypes { get; set; }
        public string ImageUrl { get; set; }
    }
}
