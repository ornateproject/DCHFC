using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
              string post_name = department.post_name;
                return RedirectToAction("selection_post", "UserDepartment", new { post_name = post_name });
            }
                        return View();
        }

        [HttpGet]
        public IActionResult selection_post(string post_name)
        {
            var usdata = _userDepRepo.getpost_details(post_name);
            UserDepartment dep_reg = new UserDepartment();
            dep_reg = JsonConvert.DeserializeObject<List<UserDepartment>>(usdata)[0];
            return View(dep_reg);
            //return View();
        }
        

        [HttpGet]
        public IActionResult selectionpost_annex1()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> selectionpost_annex1(annex1 user)
        {
            if (ModelState.IsValid)
            {
                var asd = _userDepRepo.Insertannex1Data(user);
                return RedirectToAction("regsuccess", "Regsuccess");
            }
            return View();
        }
        [HttpGet]
        public IActionResult selectionpost_annex2()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> selectionpost_annex2(annex2 user)
        {
            if (ModelState.IsValid)
            {
                var asd = _userDepRepo.Insertannex2Data(user);
                return RedirectToAction("regsuccess", "Regsuccess");
            }
            return View();
        }
        [HttpGet]
        public IActionResult selectionpost_annex3()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> selectionpost_annex3(annex3 user)
        {
            if (ModelState.IsValid)
            {
                var asd = _userDepRepo.Insertannex3Data(user);
                return RedirectToAction("regsuccess", "Regsuccess");
            }
            return View();
        }
        [HttpGet]
        public IActionResult selectionpost_annexV()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> selectionpost_annexV(annex5 user)
        {
            if (ModelState.IsValid)
            {
                var asd = _userDepRepo.InsertannexVData(user);
                return RedirectToAction("regsuccess", "Regsuccess");
            }
            return View();
        }
        [HttpGet]
        public IActionResult selectionpost_annex4()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> selectionpost_annex4(annex4 user)
        {
            if (ModelState.IsValid)
            {
                var asd = _userDepRepo.Insertannex4Data(user);
                return RedirectToAction("regsuccess", "Regsuccess");
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
    }

}

