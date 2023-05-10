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
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        //[Required(ErrorMessage = "*")]
        //public string? Mobile_no { get; set; }
        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^[6-9]{1}[0-9]{9}$", ErrorMessage = "Invalid phone number.")]
        public string? Mobile_no { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }

        //[Required(ErrorMessage = "*")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? Emailtype { get; set; }

        [Required(ErrorMessage = "Please  upload doc")]

        public IFormFile? Upload_doc { get; set; }
        public string? Doc_path { get; set; }

        public string? Status { get; set; }

        public string? phases { get; set; }

       public string? post { get; set; }

        public string? Year { get; set; }
        public string? Remark { get; set; }
       
    }
   
    public class ministry
    {
           
            public int? ministry_id { get; set; }

            public string? ministry_name { get; set; }
    }

    public class phases
    {
        public int? id { get; set; }

        public string? phase_name { get; set; }
    }
    public class ManageDepreg
    {
        public List<ministry>? Ministries { get; set; }
        public DeptRegistration? depreg { get; set; }
        public UserModel? loginuser { get; set; }
        public candidate? candidatelogin { get; set; }
        public List<phases>? phases_post { get; set; }
        public uploadcandidate? upload_data { get; set; }
        public List<candidate_doc>? upload_Doc { get; set; }

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
    public class getpost
    {
        public int id { get; set; }
        public string? Reg_no { get; set; }
        public string? Name { get; set; }
        public string? DOB { get; set; }
        public string? Email { get; set; }
        public string? Mobile_no { get; set; }
        public string? Address { get; set; }
        public string? post_name { get; set; }
        public string? post_id { get; set; }      
        public string? dep_name { get; set; }
        public string? Department { get; set; }
        public string? status { get; set; }
        public IFormFile? Upload_doc { get; set; }
        public string? is_checked { get; set; }
       
        public string? adhar_card { get; set; }
        public string? marksheet { get; set; }
        public string? Doc_path { get; set; }
        public int? isapplied { get; set; }
        public int? isfinal_submit { get; set; }
    }


    public class previewpost
    {
        public int id { get; set; }
        public string? Reg_no { get; set; }
       
        public string? post_id { get; set; }
        public string? dep_name { get; set; }
        public string? status { get; set; }     
       
        public string? Doc_path { get; set; }
    }
    public class candidatepersonaldetails
    {
        public IFormFile? adhar_card { get; set; }

        public IFormFile? marksheet { get; set; }
        public string? regNo { get; set; }
        public IFormFile? final_pdf { get; set; }
    }

    public class  candidate_doc{
        internal readonly object FileNames;

        public string? doc_name1 { get; set; }
        public IFormFile? pdfFile1 { get; set; }
        public string? doc_name2 { get; set; }
        public IFormFile? pdfFile2 { get; set; }
        public string? doc_name3 { get; set; }
        public IFormFile? pdfFile3 { get; set; }
        public string? doc_name4 { get; set; }
        public IFormFile? pdfFile4 { get; set; }
        public string? doc_name5 { get; set; }
        public IFormFile? pdfFile5 { get; set; }
        public string? doc_name6 { get; set; }
        public IFormFile? pdfFile6 { get; set; }
        public string? doc_name7 { get; set; }
        public IFormFile? pdfFile7 { get; set; }
        public string? doc_name8 { get; set; }
        public IFormFile? pdfFile8 { get; set; }
        public string? doc_name9 { get; set; }
        public IFormFile? pdfFile9 { get; set; }
        public string? doc_name10{ get; set; }
        public IFormFile? pdfFile10 { get; set; }
        public List<IFormFile> PdfFiles { get; internal set; }
    }

    public class managecandidatedata
    {
        public candidatepersonaldetails? candetails { get; set; }
        public List<getpost> getposts { get; set; }    
    }

    public class managecandidatedata_preview
    {
        public string? regNo { get; set; }
        public List<previewpost>? preposts { get; set; }
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
