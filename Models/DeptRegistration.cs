using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace ssc.Models
{
    public class DeptRegistration
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "*")]

        public string? Ministry  { get; set; }
        [Required(ErrorMessage = "*")]

        public string? Department { get; set; }
        [Required(ErrorMessage = "*")]

        public string? Name { get; set; }
        [Required(ErrorMessage = "*")]

        public string? Mobile_no { get; set; }
        [Required(ErrorMessage = "*")]


        public string? Email { get; set; }
        [Required(ErrorMessage = "*")]

        public IFormFile? Upload_doc { get; set; }
        public object Registration { get; internal set; }

        public class ministry
        {
            public List<SelectListItem> ministry_master { get; set; }
            [Key]
            public int? ministry_id { get; set; }

            public string? ministry_name { get; set; }
        }

    }
}
