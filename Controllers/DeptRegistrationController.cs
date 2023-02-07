using Microsoft.AspNetCore.Mvc;
using ssc.Data;
using ssc.Models;
using ssc.repository;
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
            var sdxf = _deptregrepo.get_ministry();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(DeptRegistration department)
        {

            if (ModelState.IsValid)
            {
                var asd = _deptregrepo.InsertpostData(department);

                return RedirectToAction("Index");
            }
            return View();

        }
            

            
    }


      
    
}


