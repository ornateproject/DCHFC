﻿using System.ComponentModel.DataAnnotations;

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
        public string? Ministry { get; set; }
        public string? Department { get; set; }
        public string? d_Name { get; set; }
        public string? d_Email { get; set; }
        public string? dep_name { get; set; }
        public string? d_Mobileno { get; set; }
        public string? postcode_reg { get; set; }
        public string? submit_date { get; set; }
        public string? ministry_name { get; set; }
        public string? Status { get; set; }

    }
    public class Managepostform
    {
        public UserDepartment? user { get; set; }
        public annex1? GetAnnex1 { get; set; }
        public annex2? GetAnnex2 { get; set; }
        public annex3? GetAnnex3 { get; set; }
        public annex4? GetAnnex4 { get; set; }
        public annex5? GetAnnex5 { get; set; }

    }
    public class dataupload
    {
        public string? Department { get; set; }
        public string? Exam { get; set; }
        public string? Year { get; set; }
        public string? upload_nomination { get; set; }
        

    }
   

    public class uploadcandidate
    {
        public string? post { get; set; }

        public string? phases { get; set; }
        public IFormFile? Upload_doc { get; set; }
       
        public string? Reg_no { get; set; }
        public string? Name { get; set; }
        public string? DOB { get; set; }
        public string? Email { get; set; }
        public string? Mobile_no { get; set; }
        public string? Address { get; set; }
    }
    public class annex1
    {
        public int id { get; set; }
        public string? Department { get; set; }
        public string? Ministry { get; set; }
        public string? F_No { get; set; }
        public string? Date { get; set; }
        public string? Recruitment_Rules { get; set; }
        public string? GSR_No { get; set; }
        public string? GSRNo_Date { get; set; }
        public string? RRs_post { get; set; }
        public string? Duties_Res { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public string? Mobile_no { get; set; }
        public string? Email { get; set; }
        public string? Place { get; set; }
        public string? RRs_date { get; set; }
    }
    public class annex2
    {
        public int id { get; set; }
        public string? Department { get; set; }
        public string? Ministry { get; set; }
        public string? F_No { get; set; }
        public string? Date { get; set; }
        public string? reported_vacancy { get; set; }
        public string? Noof_vacancy { get; set; }
        public string? certified_post { get; set; }
        public string? VH {get; set; }
        public string? HH { get; set; }
        public string? OH{ get; set; }
        public string? OTHERS { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public string? Mobile_no { get; set; }
        public string? Email { get; set; }
        public string? Place { get; set; }
        public string? Official_date { get; set; }
    }
    public class annex3
    {
        public int id { get; set; }
        public string? Department { get; set; }
        public string? Ministry { get; set; }
        public string? F_No { get; set; }
        public string? Date { get; set; }
        public string? Requisition_Form { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public string? Mobile_no { get; set; }
        public string? Email { get; set; }
        public string? Place { get; set; }
        public string? Official_date { get; set; }
    }
    public class annex4
    {
        public int id { get; set; }
        public string? Department { get; set; }
        public string? Ministry { get; set; }
        public string? F_No { get; set; }
        public string? Date { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public string? Mobile_no { get; set; }
        public string? Email { get; set; }
        public string? Place { get; set; }
        public string? Official_date { get; set; }
    }
    public class annex5
    {
        public int id { get; set; }
        public string? Department { get; set; }
        public string? Ministry { get; set; }
        public string? F_No { get; set; }
        public string? Date { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public string? Mobile_no { get; set; }
        public string? Email { get; set; }
        public string? Place { get; set; }
        public string? Official_date { get; set; }
    }
}


