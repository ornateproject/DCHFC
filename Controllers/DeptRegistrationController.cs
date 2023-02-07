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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile myfile)
        {
            //if (myfile != null)
            //{
            //    var path = Path.Combine(wwwrootDirectry, DateTime.Now.Ticks.ToString() +
            //        Path.GetExtension(myfile.FileName));

            //    using (var stream = new FileStream(path, FileMode.Create))
            //    {
            //        await myfile.CopyToAsync(stream);
            //    }
            //}

            //var vm = new DeptRegistration();
            //vm.ministry_master = ministry_Dept();
            return View(vm);

        }
            

            
    }


      
    
}


