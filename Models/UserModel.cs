using System.ComponentModel.DataAnnotations;

namespace ssc.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Prompt = "User Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Prompt = "Password")]
        public string? Password { get; set; }
    }
}
