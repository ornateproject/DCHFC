using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ssc.Models
{
    public class DeptRegistration
    {
        public int ID { get; set; }


        [StringLength(100)]
        [Required(ErrorMessage = "*")]
        public string? Ministry { get; set; }


        [StringLength(100)]
        [Required(ErrorMessage = "*")]
        public string? Department { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "*")]
        public string? Name { get; set; }

        //[Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        [Required(ErrorMessage = "*")]
        public string? Mobile_no { get; set; }


        [Required(ErrorMessage = "*")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? Email { get; set; }

        // [Required(ErrorMessage = "*")]
   
        public IFormFile? Upload_doc { get; set; }

        public string? Status { get; set; }

    }
    public class departmentReg 
    {
        public string FilePath { get; set; }
    }
    public class ministry
    {
           
            public int? ministry_id { get; set; }

            public string? ministry_name { get; set; }
    }

        public class ManageDepreg
        {
            public List<ministry>? Ministries { get; set; }
            public DeptRegistration? depreg { get; set; }
       
        }

    public class userdetails
    {
        public int ID { get; set; }
        public string? name { get; set; }
        public string? Mobile_no { get; set; }
        public string? Email { get; set; }
        public string? Upload_doc { get; set; }
        public string? dep_name { get; set; }

        
    }
     public class DepartmentData
    {
        public int? totalreg { get; set; }
        public int? approved { get; set; }
        public int? pending { get; set; }
        public int? reject { get; set; }
        public string? status { get; set; }

    }

    public enum DataStatus
    {
     
        Approved,
        Rejected,
        Cancel
    }
}
