using System.ComponentModel.DataAnnotations;

namespace DeducationApi.Models.RequestModels
{
    public class SignInRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
