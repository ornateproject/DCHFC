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

        public string? Name { get; set; }

        //[Required(ErrorMessage = "*")]
        //[Display(Prompt = "Post")]
        public string? post { get; set; }

        //[Required(ErrorMessage = "*")]
        //[Display(Prompt = "phase")]
        public string? phase { get; set; }
        public string? Year { get; set; }
        public string? loginfor { get; set; }

    }

    public class candidate
    {
        public string? id { get; set; }
        [Required(ErrorMessage = "*")]
        public string? Reg_no { get; set; }
        public string? Name { get; set; }
        //[DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString ="{0:dd/mm/yyyy}",ApplyFormatInEditMode =true)]
        [Required(ErrorMessage = "*")]
        public string? DOB { get; set; }
        public string? Email { get; set; }
        public string? Mobile_no { get; set; }
        public string? Address { get; set; }
        public string? Upload_doc { get; set; }
    }
    //public class phase
    //{
    //    public int? id { get; set; }

    //    public string? phase_name { get; set; }
    //}
    //public class managepost
    //{
    //    public UserModel? loginuser { get; set; }

    //  public List<phase>? phases_post { get; set; }
    //}
}
