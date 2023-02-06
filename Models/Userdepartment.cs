using System.ComponentModel.DataAnnotations;

namespace ssc.Models
{
    public class UserDepartment
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "*")]
        public string? post_name { get; set; }
        [Required(ErrorMessage = "*")]

        public string? pay_matrix { get; set; }
        [Required(ErrorMessage = "*")]

        public string? post_class { get; set; }
        [Required(ErrorMessage = "*")]

        public string? post_nature { get; set; }
        [Required(ErrorMessage = "*")]

        public string? initial_place { get; set; }
        [Required(ErrorMessage = "*")]

        public string? aisl { get; set; }
        [Required(ErrorMessage = "*")]

        public string? vacancy_ariesn { get; set; }
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

        public string? identified_post { get; set; }
        [Required(ErrorMessage = "*")]

        public string? disability_type { get; set; }
        [Required(ErrorMessage = "*")]

        public string? suitable_pwd { get; set; }
        [Required(ErrorMessage = "*")]

        public string? permissible { get; set; }
        [Required(ErrorMessage = "*")]

        public string? VH { get; set; }
        [Required(ErrorMessage = "*")]

        public string? HH { get; set; }
        [Required(ErrorMessage = "*")]

        public string? OH { get; set; }
        [Required(ErrorMessage = "*")]

        public string? OTHERS { get; set; }
        [Required(ErrorMessage = "*")]

        public string? Total_vacancy { get; set; }
        [Required(ErrorMessage = "*")]

        public string? reserved_vacancy { get; set; }
        [Required(ErrorMessage = "*")]

      

        public string? pwd_number { get; set; }
        [Required(ErrorMessage = "*")]

        public string? pwdvertical_category { get; set; }
        [Required(ErrorMessage = "*")]

        public string? totalesm_number { get; set; }
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

        public string? Age_limit { get; set; }
        [Required(ErrorMessage = "*")]

        public string? Requirment { get; set; }
        [Required(ErrorMessage = "*")]

        public string? Name { get; set; }
        [Required(ErrorMessage = "*")]

        public string? Desigantion { get; set; }
        [Required(ErrorMessage = "*")]

        public string? Address { get; set; }
        [Required(ErrorMessage = "*")]

        

        public string? Mobile_no { get; set; }
        [Required(ErrorMessage = "*")]

        public string? Email { get; set; }
        [Required(ErrorMessage = "*")]

        public string? subsequent_orders { get; set; }
        [Required(ErrorMessage = "*")]

        public string? DOPT_letter { get; set; }
        [Required(ErrorMessage = "*")]

        public string? no_ofvacancy { get; set; }
        [Required(ErrorMessage = "*")]

        public string? pwd_esm { get; set; }
        [Required(ErrorMessage = "*")]

        public string? person_disabilities { get; set; }
        [Required(ErrorMessage = "*")]

        public string? letter_no { get; set; }
        [Required(ErrorMessage = "*")]

        public string? office_department { get; set; }
        
    }
    
}


