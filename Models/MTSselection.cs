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
        public string? age_limit { get; set; }

        [Required(ErrorMessage = "*")]
        public string? post_classification { get; set; }

        [Required(ErrorMessage = "*")]
        public string? initial_post { get; set; }

        [Required(ErrorMessage = "*")]
        public string? AISL { get; set; }


        [Required(ErrorMessage = "*")]
        public string? vacancy_ariesn { get; set; }


        [Required(ErrorMessage = "*")]
        public string? identified_post { get; set; }


        [Required(ErrorMessage = "*")]
        public string? disability_type { get; set; }


        [Required(ErrorMessage = "*")]
        public string? PWD_suitable { get; set; }


        [Required(ErrorMessage = "*")]
        public string? permissible_disability { get; set; }


        [Required(ErrorMessage = "*")]
        public string? UR { get; set; }


        [Required(ErrorMessage = "*")]
        public string? OBC { get; set; }


        [Required(ErrorMessage = "*")]
        public string? SC { get; set; }


        [Required(ErrorMessage = "*")]
        public string? ST { get; set; }


        [Required(ErrorMessage = "*")]
        public string? EWS { get; set; }


        [Required(ErrorMessage = "*")]
        public string? TOTAL { get; set; }

        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? VH { get; set; }



        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? HH { get; set; }


        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? OH { get; set; }

        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? OTHERS { get; set; }


        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? Total_vacancy { get; set; }

        [Required(ErrorMessage = "*")]
        //[Required]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? ESM_number { get; set; }


        [Required(ErrorMessage = "*")]
        public string? probation_period { get; set; }


        [Required(ErrorMessage = "*")]
        public string? Essential { get; set; }



        [Required(ErrorMessage = "*")]
        public string? desirable { get; set; }


        [Required(ErrorMessage = "*")]
        public string? relaxation { get; set; }


        [Required(ErrorMessage = "*")]
        public string? Age_requirment { get; set; }


        [Required(ErrorMessage = "*")]
        public string? other_requirment { get; set; }

        [Required(ErrorMessage = "*")]
        public string? subsequent_oders { get; set; }

        [Required(ErrorMessage = "*")]
        public string? CCS_rules { get; set; }

        [Required(ErrorMessage = "*")]
        public string? reserved_vacancies { get; set; }

        [Required(ErrorMessage = "*")]
        public string? DOPT_refrence { get; set; }

        [Required(ErrorMessage = "*")]
        public string? Persons_disabilities { get; set; }



        [Required(ErrorMessage = "*")]
        //[Required]
       // [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? Previous_requisition { get; set; }


        [Required(ErrorMessage = "*")]
        //[Required]
        //[RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter Number")]
        public string? candidates_nominated { get; set; }







    }
}
