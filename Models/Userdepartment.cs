using System.ComponentModel.DataAnnotations;

namespace ssc.Models
{
    public class UserDepartment
    {
        public int ID { get; set; }


        //[StringLength(100, ErrorMessage = "Enter a valid name")]
        [Required(ErrorMessage = "*")]
        public string? post_name { get; set; }


        [Required(ErrorMessage = "*")]
        public string? pay_matrix { get; set; }

        //[StringLength(100, ErrorMessage = "Enter a valid Post Class")]
        [StringLength(100, ErrorMessage = "*")]
        [Required(ErrorMessage = "*")]
        public string? post_class { get; set; }

        //[StringLength(100, ErrorMessage = "Enter a valid Post Nature")]
        [Required(ErrorMessage = "*")]
        public string? post_nature { get; set; }

        
        [Required(ErrorMessage = "*")]
        public string? initial_place { get; set; }

        //[StringLength(100, ErrorMessage = "Enter a valid AISL")]
        [Required(ErrorMessage = "*")]
        public string? aisl { get; set; }


        [Required(ErrorMessage = "*")]
        public string? vacancy_ariesn { get; set; }

        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        [Required(ErrorMessage = "*")]
        public string? UR { get; set; }


        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        [Required(ErrorMessage = "*")]
        public string? OBC { get; set; }

        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        [Required(ErrorMessage = "*")]
        public string? SC { get; set; }

        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        [Required(ErrorMessage = "*")]
        public string? ST { get; set; }

        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        [Required(ErrorMessage = "*")]
        public string? EWS { get; set; }

        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        [Required(ErrorMessage = "*")]
        public string? TOTAL { get; set; }


        
        [Required(ErrorMessage = "*")]
        public string? identified_post { get; set; }


        [Required(ErrorMessage = "*")]
        public string? disability_type { get; set; }


        //[Required(ErrorMessage = "*")]
        public string? suitable_pwd { get; set; }


        [Required(ErrorMessage = "*")]
        public string? permissible { get; set; }

        
        [Required(ErrorMessage = "*")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        public string? VH { get; set; }


        [Required(ErrorMessage = "*")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        public string? HH { get; set; }


        [Required(ErrorMessage = "*")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        public string? OH { get; set; }

        [Required(ErrorMessage = "*")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        public string? OTHERS { get; set; }


        //[Required(ErrorMessage = "*")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        public string? Total_vacancy { get; set; }


        [Required(ErrorMessage = "*")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        public string? reserved_vacancy { get; set; }

        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        [Required(ErrorMessage = "*")]     
         public string? pwd_number { get; set; }

        [Required(ErrorMessage = "*")]
        public string? pwdvertical_category { get; set; }

//        [RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        [Required(ErrorMessage = "*")]
        public string? totalesm_number { get; set; }

  //      [RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        [Required(ErrorMessage = "*")]
        public string? esm_number { get; set; }

        [Required(ErrorMessage = "*")]
        public string? esmvertical_category { get; set; }

        [Required(ErrorMessage = "*")]
        public string? probation1 { get; set; }

        [Required(ErrorMessage = "*")]
        public string? Essential { get; set; }


        [Required(ErrorMessage = "*")]
        public string? Desirable { get; set; }

        [Required(ErrorMessage = "*")]
        public string? Relaxation { get; set; }

        [Required(ErrorMessage = "*")]
        public string? Regional_office { get; set; }


        [Required(ErrorMessage = "*")]
        //[Range(18, 30, ErrorMessage = "Enter number between 18 to 30")]
        public string? Age_limit { get; set; }

        [Required(ErrorMessage = "*")]
        public string? Requirment { get; set; }

        [Required(ErrorMessage = "*")]
        //[StringLength(100,ErrorMessage ="Enter a valid name")] 
        public string? Name { get; set; }




        [Required(ErrorMessage = "*")]
        //[StringLength(100, ErrorMessage = "Enter a valid Destination")]
        public string? Desigantion { get; set; }


        [Required(ErrorMessage = "*")]
        //[StringLength(200, ErrorMessage = " Enter a  valid Address")]
        [MinLength(1)]
        public string? Address { get; set; }


        
        [Phone]
        [MaxLength(10), MinLength(10)]
        [Required(ErrorMessage = "*")]
        public string? Mobile_no { get; set; }




        [Required(ErrorMessage = "*")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? Email { get; set; }



        [Required(ErrorMessage = "*")]
        public string? subsequent_orders { get; set; }

        [Required(ErrorMessage = "*")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        public string? DOPT_letter { get; set; }

        [Required(ErrorMessage = "*")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        public string? no_ofvacancy { get; set; }

        [Required(ErrorMessage = "*")]
        public string? pwd_esm { get; set; }

        [Required(ErrorMessage = "*")]
        public string? person_disabilities { get; set; }
        
        [Required(ErrorMessage = "*")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Enter a valid number")]
        public string? letter_no { get; set; }

        [Required(ErrorMessage = "*")]
        public string? office_department { get; set; }
        
    }
    
}


