using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Data;
using ssc.Models;
using ssc.repository;
using System.Data;
using static ssc.Models.DeptRegistration;

namespace ssc.Controllers
{
    public class DeptRegistrationController : Controller
    {
      //  private readonly string wwwrootDirectry = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private readonly Deptregrepo _deptregrepo;

        public DeptRegistrationController(IConfiguration configuration)
        {
            _deptregrepo = new Deptregrepo(configuration);
        }

        [HttpGet]
        public IActionResult Index()
        {
             var ministry= _deptregrepo.get_ministry();
            ManageDepreg manageDepreg = new ManageDepreg();
    
            manageDepreg.Ministries = JsonConvert.DeserializeObject<List<ministry>>(ministry);
            return View(manageDepreg);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ManageDepreg department)
        {
           
            if (ModelState.IsValid)
            {
                var asd = _deptregrepo.InsertpostData(department.depreg);
                var file = Request.Form.Files.FirstOrDefault();
                if (file == null || file.Length == 0)
                {
                    return BadRequest("File not selected.");
                }

                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                var base64String = Convert.ToBase64String(fileBytes);

            }
            var ministry = _deptregrepo.get_ministry();
            ManageDepreg manageDepreg = new ManageDepreg();
            manageDepreg.Ministries = JsonConvert.DeserializeObject<List<ministry>>(ministry);
            return View(manageDepreg);

        }

        [HttpPost]
        public IActionResult UploadFile()
        {
            var file = Request.Form.Files.FirstOrDefault();
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected.");
            }

            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            var base64String = Convert.ToBase64String(fileBytes);
            // do something with the base64 string here

            return Ok();
        }
        







        public string getdepartment(int id)
        {
            var dep = _deptregrepo.get_deparment(id);
            
            return JsonConvert.SerializeObject(dep);
        }

        //[HttpPost]
        



    }


      
    
}


