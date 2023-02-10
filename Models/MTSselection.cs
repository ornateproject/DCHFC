using System;
using System.ComponentModel.DataAnnotations;

namespace ssc.Models
{
    public class MTSselection
    {
        public int ID { get; set; }


        //[StringLength(100, ErrorMessage = "Enter a valid name")]
        [Required(ErrorMessage = "*")]
        public string? post_name { get; set; }


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


        [Required(ErrorMessage = "*")]
        public string? obc_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? sc_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? st_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? ews_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? total_type { get; set; }

        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? vh_type { get; set; }



        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? hh_type { get; set; }


        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? oh_type { get; set; }

        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? other_type { get; set; }


        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? vac_type { get; set; }

        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? num_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? prob_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? essen_type { get; set; }



        [Required(ErrorMessage = "*")]
        public string? desirable_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? relaxation_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? rule_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? column_type { get; set; }

        [Required(ErrorMessage = "*")]
        public string? order_type { get; set; }

        [Required(ErrorMessage = "*")]
        public string? enclose_type { get; set; }

        [Required(ErrorMessage = "*")]
        public string? subsequent_type { get; set; }

        [Required(ErrorMessage = "*")]
        public string? worked_type { get; set; }

        [Required(ErrorMessage = "*")]
        public string? complied_type { get; set; }



        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? office_type { get; set; }


        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? deptt_type { get; set; }







    }
}
