using System.ComponentModel.DataAnnotations;

namespace ssc.Models
{
    public class MTSselection
    {
        public int ID { get; set; }


        //[StringLength(100, ErrorMessage = "Enter a valid name")]
            [Required(ErrorMessage = "*")]
           public string? post_name{ get; set; }


        [Required(ErrorMessage = "*")]
        public string? pay_matrix { get; set; }


        [Required(ErrorMessage = "*")]
        public string? limit_age { get; set; }

        [Required(ErrorMessage = "*")]
        public string? post_class { get; set; }

        [Required(ErrorMessage = "*")]
        public string? post_initial { get; set; }

        [Required(ErrorMessage = "*")]
        public string? liability_service { get; set; }


        [Required(ErrorMessage = "*")]
        public string? arisen { get; set; }


        [Required(ErrorMessage = "*")]
        public string? disable { get; set; }


        [Required(ErrorMessage = "*")]
        public string? disability_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? pwd_suitable { get; set; }


        [Required(ErrorMessage = "*")]
        public string? per_dis { get; set; }


        [Required(ErrorMessage = "*")]
        public string? ur_type { get; set; }







    }
}
