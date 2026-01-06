using System.ComponentModel.DataAnnotations;

namespace GearTalk.Web.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password has to be atleast 6 charachters!")]
        [RegularExpression(@"^(?=.*[A-Z]).*$",
          ErrorMessage = "Password must contain at least one uppercase letter.")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
