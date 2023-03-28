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
                int abc = Convert.ToInt32(department.UR) + Convert.ToInt32(department.OBC) + Convert.ToInt32(department.SC) + Convert.ToInt32(department.ST) + Convert.ToInt32(department.EWS);
                department.TOTAL = Convert.ToString(abc);
                int myint = Convert.ToInt32(department.VH) + Convert.ToInt32(department.HH) + Convert.ToInt32(department.OH) + Convert.ToInt32(department.OTHERS);
                department.Total_vacancy = Convert.ToString(myint);
                department.ID = Convert.ToInt32(HttpContext.Session.GetString("department"));
                var asd = _userDepRepo.InsertpostData(department);               

                return RedirectToAction("us2","US2");
            }
                        return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        
    }

}

