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
    //public class ministryModel
    //{
    //    public int ministry_id { get; set; }
    //    public string? ministry_name { get; set; }
    //}
}
