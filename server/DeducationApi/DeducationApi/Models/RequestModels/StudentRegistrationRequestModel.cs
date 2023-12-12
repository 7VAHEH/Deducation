using System.ComponentModel.DataAnnotations;

namespace DeducationApi.Models.RequestModels
{
    public class StudentRegistrationRequestModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Birthdate { get; set; }

        public string Country { get; set; }

        public string Faculty { get; set; }

        public string ClassOf { get; set; }

        public bool IsStudent { get; set; }

        public string[]? Preferences { get; set; }

        public string University { get; set; }
    }
}
