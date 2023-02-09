using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace ssc.Models
{
    public class DeptRegistration
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "*")]
        public string? Ministry { get; set; }


        [Required(ErrorMessage = "*")]
        public string? Department { get; set; }

        [Required(ErrorMessage = "*")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "*")]
        public string? Mobile_no { get; set; }

        [Required(ErrorMessage = "*")]

        public string? Email { get; set; }

        public IFormFile? Upload_doc { get; set; }
        //public IEnumerable<SelectListItem> ministry_name { get;  set; }
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
        public string? name { get; set; }
        public string? Mobile_no { get; set; }
        public string? Email { get; set; }
        public string? Upload_doc { get; set; }
        public string? dep_name { get; set; }
    }
    
}
