using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GearTalk.Web.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6,ErrorMessage = "Password has to be atleast 6 charachters!")]
        [RegularExpression(@"^(?=.*[A-Z]).*$",
          ErrorMessage = "Password must contain at least one uppercase letter.")]

        public string Password { get; set; }
             
    }
}
