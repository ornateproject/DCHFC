using System.ComponentModel.DataAnnotations;

namespace ssc.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "*")]
        // [Display(Prompt = "User Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "*")]
        //[Display(Prompt = "Password")]
        public string? Password { get; set; }

        public string? phase { get; set; }

        public string? post { get; set; }

        public string? Year { get; set; }

    }
    public class phase
    {
        public int? id { get; set; }

        public string? phase_name { get; set; }
    }
    public class managepost
    {
        public UserModel? loginuser { get; set; }

      public List<phase>? phase_post { get; set; }
    }
}
