using Microsoft.AspNetCore.Mvc;
using ssc.Data;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class UserDepartmentController : Controller
    {

        private readonly UserDepRepo _userDepRepo;
        public UserDepartmentController(IConfiguration configuration)
        {
            _userDepRepo = new UserDepRepo(configuration);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(UserDepartment department)
        {
            if (ModelState.IsValid)
            {
                // OB SC  ST EWS TOTAL
                department.TOTAL = department.UR +department.OBC + department.SC + department.ST + department.EWS;

                department.Total_vacancy= department.VH + department.HH + department.OH + department.OTHERS;
                var asd = _userDepRepo.InsertpostData(department);               

                return RedirectToAction("Index");
            }
                        return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        
    }

}

