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
        private readonly string wwwrootDirectry = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
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

                return RedirectToAction("Index");
            }
            var ministry = _deptregrepo.get_ministry();
            ManageDepreg manageDepreg = new ManageDepreg();
            manageDepreg.Ministries = JsonConvert.DeserializeObject<List<ministry>>(ministry);

            return View(manageDepreg);

        }

        public async Task<IActionResult> GetPdfFile(int id)
        {
            //var deliveryUpload = await _deptregrepo.GetPdfFile.FindAsync(id);
            //if (deliveryUpload == null)
            //    return NotFound();

            //return File(deliveryUpload.Files, "pdf", "delivery-upload.pdf");
            return View();
        }

        public string getdepartment(int id)
        {
            var dep = _deptregrepo.get_deparment(id);
            
            return JsonConvert.SerializeObject(dep);
        }



    }


      
    
}


